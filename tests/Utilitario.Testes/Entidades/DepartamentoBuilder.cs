namespace Utilitario.Testes.Entidades;

    public class DepartamentoBuilder
    {
        public static Departamento Construir(int id, Setor setor)
        {
            return new Faker<Departamento>()
            .RuleFor(c => c.Id, _ => id)
            .RuleFor(c => c.Nome, f => f.Commerce.Department())
            .RuleFor(c => c.SetorId, _ => setor.Id);
        }
    }
