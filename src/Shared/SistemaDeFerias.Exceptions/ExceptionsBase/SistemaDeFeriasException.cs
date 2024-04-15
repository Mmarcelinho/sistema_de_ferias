namespace SistemaDeFerias.Exceptions.ExceptionsBase;

    [Serializable]
    public class SistemaDeFeriasException : SystemException
    { 
        public SistemaDeFeriasException(string mensagem) : base(mensagem) { }
    }
