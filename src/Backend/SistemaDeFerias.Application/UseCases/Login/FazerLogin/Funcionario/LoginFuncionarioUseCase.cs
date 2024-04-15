using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;

public class LoginFuncionarioUseCase : ILoginFuncionarioUseCase
{
    private readonly IFuncionarioReadOnlyRepositorio _funcionarioReadOnlyRepositorio;

    private readonly EncriptadorDeSenha _encriptadorDeSenha;

    private readonly TokenController _tokenController;

    public LoginFuncionarioUseCase(IFuncionarioReadOnlyRepositorio funcionarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _funcionarioReadOnlyRepositorio = funcionarioReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginFuncionarioJson> Executar(RequisicaoLoginFuncionarioJson requisicao)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);

        var funcionario = await _funcionarioReadOnlyRepositorio.RecuperarPorEmailSenha(requisicao.Email, senhaCriptografada);

        if (funcionario is null)
            throw new LoginInvalidoException();

        return new RespostaLoginFuncionarioJson(funcionario.Nome,
            _tokenController.GerarToken(funcionario.Email));
    }
}
