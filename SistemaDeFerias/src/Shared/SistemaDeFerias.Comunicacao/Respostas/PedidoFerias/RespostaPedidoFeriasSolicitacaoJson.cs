namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

    public record RespostaPedidoFeriasSolicitacaoJson(string Id, DateTime DataPedido, DateTime DataInicio, DateTime DataFim, int Dias);