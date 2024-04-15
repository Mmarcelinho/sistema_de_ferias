namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

public record RespostaPedidoFeriasJson(string Id, string DataPedido, string DataInicio, string DataFim, int Dias);