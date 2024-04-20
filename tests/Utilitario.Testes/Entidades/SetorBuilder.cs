namespace Utilitario.Testes.Entidades;

    public class SetorBuilder
    {
        public static Setor Construir(int id)
        {
            return new Faker<Setor>()
            .RuleFor(c => c.Id, _ => id)
            .RuleFor(c => c.Nome, f => f.Commerce.Department());
        }
    }
