using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;

public class RegistrarFuncionarioUseCase : IRegistrarFuncionarioUseCase
{
    private readonly IFuncionarioReadOnlyRepositorio _funcionarioReadOnlyRepositorio;
    private readonly IFuncionarioWriteOnlyRepositorio _repositorio;
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;

    public RegistrarFuncionarioUseCase(IFuncionarioWriteOnlyRepositorio repositorio, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho,
        EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController, IFuncionarioReadOnlyRepositorio funcionarioReadOnlyRepositorio)
    {
        _repositorio = repositorio;
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
        _funcionarioReadOnlyRepositorio = funcionarioReadOnlyRepositorio;
    }

    public async Task<RespostaFuncionarioRegistradoJson> Executar(RequisicaoRegistrarFuncionarioJson requisicao)
    {
        await Validar(requisicao);

        var entidade = _mapper.Map<Domain.Entidades.Funcionario>(requisicao);
        entidade.Senha = _encriptadorDeSenha.Criptografar(requisicao.Senha);
        
        await _repositorio.Adicionar(entidade);

        await _unidadeDeTrabalho.Commit();
        
        var token = _tokenController.GerarToken(entidade.Email);

        return new RespostaFuncionarioRegistradoJson(token);
    }

     private async Task Validar(RequisicaoRegistrarFuncionarioJson requisicao)
    {
        var validator = new RegistrarFuncionarioValidator();
        var resultado = validator.Validate(requisicao);

        var existeUsuarioComEmail = await _funcionarioReadOnlyRepositorio.ExisteFuncionarioComEmail(requisicao.Email);
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
