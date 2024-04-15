namespace SistemaDeFerias.Domain.Entidades;

    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Funcao { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataUltimaFerias { get; set; }

        public long DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<PedidoFerias> PedidosFerias { get; set; }
    }
