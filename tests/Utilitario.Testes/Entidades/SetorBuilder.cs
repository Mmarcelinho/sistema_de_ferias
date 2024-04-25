namespace Utilitario.Testes.Entidades;

    public class SetorBuilder
    {
        public static Setor Construir(long id = 1)
        {
            return new Faker<Setor>()
            .RuleFor(c => c.Id, _ => id)
            .RuleFor(c => c.Nome, f => f.Commerce.Department());
        }
    }
