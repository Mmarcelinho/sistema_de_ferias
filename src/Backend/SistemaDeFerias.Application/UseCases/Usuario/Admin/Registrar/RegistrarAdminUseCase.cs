namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;

public class RegistrarAdminUseCase : IRegistrarAdminUseCase
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;
    private readonly IAdminWriteOnlyRepositorio _repositorio;
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;

    public RegistrarAdminUseCase(IAdminWriteOnlyRepositorio repositorio, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho,
        EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController, IAdminReadOnlyRepositorio adminReadOnlyRepositorio)
    {
        _repositorio = repositorio;
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
    }

    public async Task<RespostaAdminRegistradoJson> Executar(RequisicaoRegistrarAdminJson requisicao)
    {
        await Validar(requisicao);

        var entidade = _mapper.Map<Domain.Entidades.Admin>(requisicao);
        entidade.Senha = _encriptadorDeSenha.Criptografar(requisicao.Senha);
        
        await _repositorio.Adicionar(entidade);

        await _unidadeDeTrabalho.Commit();
        
        var token = _tokenController.GerarToken(entidade.Email);

        return new RespostaAdminRegistradoJson(token);
    }

     private async Task Validar(RequisicaoRegistrarAdminJson requisicao)
    {
        var validator = new RegistrarAdminValidator();
        var resultado = validator.Validate(requisicao);

        var existeUsuarioComEmail = await _adminReadOnlyRepositorio.ExisteAdminComEmail(requisicao.Email);
        if (existeUsuarioComEmail)
        {
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMensagensDeErro.EMAIL_JA_REGISTRADO));
        }

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}
