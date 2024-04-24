namespace Utilitario.Testes.Requisicoes.PedidoFerias;

    public class RequisicaoAnalisarPedidoFeriasBuilder
    {
        public static RequisicaoAnalisarPedidoFeriasJson Construir()
    {
        return new Faker<RequisicaoAnalisarPedidoFeriasJson>()
        .RuleFor(c => c.Status, f => f.PickRandom<Status>());
    }
    }