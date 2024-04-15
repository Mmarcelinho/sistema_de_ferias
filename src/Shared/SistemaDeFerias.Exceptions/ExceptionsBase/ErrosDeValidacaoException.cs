namespace SistemaDeFerias.Exceptions.ExceptionsBase;

public class ErrosDeValidacaoException : SistemaDeFeriasException
{
    public List<string> MensagensDeErro { get; set; }
    public ErrosDeValidacaoException(List<string> mensagensDeErro) : base(string.Empty) =>
    
        MensagensDeErro = mensagensDeErro;
}
