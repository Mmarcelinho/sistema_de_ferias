namespace SistemaDeFerias.Domain.Entidades;

    public class Funcionario : Usuario
    {
        public string Funcao { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataUltimaFerias { get; set; }

        public long DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<PedidoFerias> PedidosFerias { get; set; }
    }
