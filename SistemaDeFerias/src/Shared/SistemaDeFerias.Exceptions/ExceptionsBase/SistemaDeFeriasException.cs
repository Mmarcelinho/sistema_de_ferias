using System.Runtime.Serialization;

namespace SistemaDeFerias.Exceptions.ExceptionsBase;

    [Serializable]
    public class SistemaDeFeriasException : SystemException
    {
        
        public SistemaDeFeriasException(string mensagem) : base(mensagem) { }

        protected SistemaDeFeriasException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }