namespace SistemaDeFerias.Comunicacao.Respostas.Admin;

public record RespostaDashboardPedidosAdminJson(string Id, string DataPedido, string DataInicio, string DataFim, int Dias, Enum.Status Status);

public record RespostaDashboardAdminJson
{
    public List<RespostaDashboardPedidosAdminJson> Pedidos { get; init; }
}