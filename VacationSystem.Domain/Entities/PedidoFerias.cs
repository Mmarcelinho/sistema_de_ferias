using VacationSystem.Domain.Entities.Shared;

namespace VacationSystem.Domain.Entities;

    public class PedidoFerias : Entity
    {
        public int FuncionarioId { get; private set; }

        public int AdminId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public Admin Admin { get; private set; }

        public DateTime DataPedido { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }

        public int Dias { get; private set; }

        public string Status { get; private set; }
    }
