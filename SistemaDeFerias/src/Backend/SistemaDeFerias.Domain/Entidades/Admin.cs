namespace SistemaDeFerias.Domain.Entidades;

    public class Admin : EntidadeBase
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Cargo { get; set; }

        public bool Administrador { get; set; }

        public long DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<PedidoFerias> PedidoFeriasAnalisados { get; set; }
    }
