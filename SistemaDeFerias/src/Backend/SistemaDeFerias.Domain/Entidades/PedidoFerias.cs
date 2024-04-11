using SistemaDeFerias.Domain.Enum;

namespace SistemaDeFerias.Domain.Entidades;

    public class PedidoFerias : EntidadeBase
    {
        public long FuncionarioId { get; set; }

        public long AdminId { get; set; }

        public DateTime DataPedido { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Dias { get; set; }

        public Status Status { get; set; }

        public Funcionario Funcionario { get; set; }

        public Admin Admin { get; set; }
    }
