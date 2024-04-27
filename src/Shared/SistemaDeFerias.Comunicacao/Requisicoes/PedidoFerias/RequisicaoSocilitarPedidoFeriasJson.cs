namespace SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

public record RequisicaoSolicitarPedidoFeriasJson
{
    public DateTime DataInicio { get; init; }
    public int Dias { get; init; }
}
