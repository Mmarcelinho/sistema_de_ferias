namespace SistemaDeFerias.Domain.Entidades;

    public class Departamento : EntidadeBase
    {
        public string Nome { get; set; }

        public long SetorId { get; set; }

        public Setor Setor { get; set; }

        public ICollection<Admin> Admins { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
