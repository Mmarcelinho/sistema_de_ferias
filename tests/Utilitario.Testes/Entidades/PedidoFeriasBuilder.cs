namespace Utilitario.Testes.Entidades;

    public class PedidoFeriasBuilder
    {
        public static PedidoFerias Construir(long Id)
        {
            return new Faker<PedidoFerias>()
            .RuleFor(c => c.Id, _ => Id)
            .RuleFor(c => c.DataInicio, f => f.Date.Between(DateTime.Now,DateTime.Now.AddDays(30)))
            .RuleFor(c => c.Dias, 30)
            .RuleFor(c => c.FuncionarioId, _ => Id)
            .RuleFor(c => c.Status, f => SistemaDeFerias.Domain.Enum.Status.Pendente);
        }
    }
