using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

namespace Utilitario.Testes.Requisicoes.PedidoFerias;

public class RequisicaoSolicitarPedidoFeriasBuilder
{
    public static RequisicaoSolicitarPedidoFeriasJson Construir()
    {
        return new Faker<RequisicaoSolicitarPedidoFeriasJson>()
        .RuleFor(c => c.DataInicio, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(30)))
        .RuleFor(c => c.Dias, 30);
    }
}