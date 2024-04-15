namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

    public record RespostaPedidoFeriasSolicitacaoJson(string Id, string DataPedido, string DataInicio, string DataFim, int Dias);