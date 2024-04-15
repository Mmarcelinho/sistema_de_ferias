namespace SistemaDeFerias.Comunicacao.Respostas.Funcionario;

public record RespostaDashboardFuncionarioJson
{
    public List<RespostaDashboardPedidosFuncionarioJson> Pedidos { get; init; }
}