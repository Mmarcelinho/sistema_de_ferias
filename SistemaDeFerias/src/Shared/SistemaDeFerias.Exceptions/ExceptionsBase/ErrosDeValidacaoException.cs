using System.Runtime.Serialization;

namespace SistemaDeFerias.Exceptions.ExceptionsBase;

[Serializable]
public class ErrosDeValidacaoException : SistemaDeFeriasException
{
    public List<string> MensagensDeErro { get; set; }
    public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty) =>
    
        MensagensDeErro = mensagensDeErro;
    

    protected ErrosDeValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}
