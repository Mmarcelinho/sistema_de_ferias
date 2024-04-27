using SistemaDeFerias.Comunicacao.Enum;

namespace SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

    public record RequisicaoAnalisarPedidoFeriasJson
    {
        public Status Status { get; init; }
    }
