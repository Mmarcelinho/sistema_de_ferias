namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.AlterarSenha;

public class AlterarSenhaAdminUseCase : IAlterarSenhaAdminUseCase
{
    private readonly IAdminLogado _adminLogado;
    private readonly IAdminUpdateOnlyRepositorio _repositorio;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AlterarSenhaAdminUseCase(IAdminUpdateOnlyRepositorio repositorio, IAdminLogado adminLogado, EncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _adminLogado = adminLogado;
        _encriptadorDeSenha = encriptadorDeSenha;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Executar(RequisicaoAlterarSenhaJson requisicao)
    {
        var adminLogado = await _adminLogado.RecuperarAdmin();

        var admin = await _repositorio.RecuperarPorId(adminLogado.Id);

        Validar(requisicao, admin);

        admin.Senha = _encriptadorDeSenha.Criptografar(requisicao.NovaSenha);

        _repositorio.Atualizar(admin);

        await _unidadeDeTrabalho.Commit();
    }

    private void Validar(RequisicaoAlterarSenhaJson requisicao, Domain.Entidades.Admin admin)
    {
        var validator = new AlterarSenhaValidator();
        var resultado = validator.Validate(requisicao);

        var senhaAtualCriptografada = _encriptadorDeSenha.Criptografar(requisicao.SenhaAtual);

        if (!admin.Senha.Equals(senhaAtualCriptografada))
        {
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("senhaAtual", ResourceMensagensDeErro.SENHA_ATUAL_INVALIDA));
        }

        if (!resultado.IsValid)
        {
            var mensagens = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagens);
        }
    }
}