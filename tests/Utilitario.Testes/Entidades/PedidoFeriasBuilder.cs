namespace Utilitario.Testes.Entidades;

    public class PedidoFeriasBuilder
    {
        public static PedidoFerias Construir(long id = 1)
        {
            return new Faker<PedidoFerias>()
            .RuleFor(c => c.Id, _ => id)
            .RuleFor(c => c.DataInicio, f => f.Date.Between(DateTime.Now,DateTime.Now.AddDays(30)))
            .RuleFor(c => c.DataFim, f => f.Date.Between(DateTime.Now.AddDays(30),DateTime.Now.AddDays(60)))
            .RuleFor(c => c.Dias, 30)
            .RuleFor(c => c.FuncionarioId, _ => id)
            .RuleFor(c => c.Status, f => SistemaDeFerias.Domain.Enum.Status.Pendente);
        }
    }
