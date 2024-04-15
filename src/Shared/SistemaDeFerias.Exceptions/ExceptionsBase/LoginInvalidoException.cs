namespace SistemaDeFerias.Exceptions.ExceptionsBase;

public class LoginInvalidoException : SistemaDeFeriasException
{
    public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO)
    { }
}
