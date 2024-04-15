namespace SistemaDeFerias.Domain.Entidades;

    public class Setor : EntidadeBase
    {
        public string Nome { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }
    }
