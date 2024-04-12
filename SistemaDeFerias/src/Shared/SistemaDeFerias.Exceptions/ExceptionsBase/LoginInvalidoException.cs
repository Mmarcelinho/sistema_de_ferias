using System.Runtime.Serialization;

namespace SistemaDeFerias.Exceptions.ExceptionsBase;

[Serializable]
public class LoginInvalidoException : SistemaDeFeriasException
{
    public LoginInvalidoException() : base(ResourceMensagensDeErro.LOGIN_INVALIDO)
    { }

    protected LoginInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}
