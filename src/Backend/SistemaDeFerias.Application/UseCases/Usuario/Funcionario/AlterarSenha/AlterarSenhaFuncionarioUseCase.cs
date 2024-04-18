namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.AlterarSenha;

public class AlterarSenhaFuncionarioUseCase : IAlterarSenhaFuncionarioUseCase
{
    private readonly IFuncionarioLogado _funcionarioLogado;
    private readonly IFuncionarioUpdateOnlyRepositorio _repositorio;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AlterarSenhaFuncionarioUseCase(IFuncionarioUpdateOnlyRepositorio repositorio, IFuncionarioLogado funcionarioLogado, EncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _funcionarioLogado = funcionarioLogado;
        _encriptadorDeSenha = encriptadorDeSenha;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Executar(RequisicaoAlterarSenhaJson requisicao)
    {
        var funcionarioLogado = await _funcionarioLogado.RecuperarUsuario();

        var funcionario = await _repositorio.RecuperarPorId(funcionarioLogado.Id);

        Validar(requisicao,funcionario);

        funcionario.Senha = _encriptadorDeSenha.Criptografar(requisicao.NovaSenha);

        _repositorio.Atualizar(funcionario);

        await _unidadeDeTrabalho.Commit();
    }

    private void Validar(RequisicaoAlterarSenhaJson requisicao, Domain.Entidades.Funcionario funcionario)
    {
        var validator = new AlterarSenhaValidator();
        var resultado = validator.Validate(requisicao);

        var senhaAtualCriptografada = _encriptadorDeSenha.Criptografar(requisicao.SenhaAtual);

        if (!funcionario.Senha.Equals(senhaAtualCriptografada))
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