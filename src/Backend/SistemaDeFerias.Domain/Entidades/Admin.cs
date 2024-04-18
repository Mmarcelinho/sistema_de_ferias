namespace SistemaDeFerias.Domain.Entidades;

    public class Admin : Usuario
    {
        public string Cargo { get; set; }

        public bool Administrador { get; set; }

        public long DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<PedidoFerias> PedidoFeriasAnalisados { get; set; }
    }
