namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;

public class LoginFuncionarioUseCase : LoginUsuarioUseCase<Domain.Entidades.Funcionario>, ILoginFuncionarioUseCase
{
    public LoginFuncionarioUseCase(
        IUsuarioReadOnlyRepositorio<Domain.Entidades.Funcionario> usuarioReadOnlyRepositorio, 
        EncriptadorDeSenha encriptadorDeSenha, 
        TokenController tokenController) : 
        base(usuarioReadOnlyRepositorio, encriptadorDeSenha, tokenController)
        { }
}
