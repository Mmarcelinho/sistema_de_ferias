namespace SistemaDeFerias.Comunicacao.Respostas.Admin;

public record RespostaDashboardAdminJson
{
    public List<RespostaDashboardPedidosAdminJson> Pedidos { get; init; }
}