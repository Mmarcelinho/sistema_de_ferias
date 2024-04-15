namespace SistemaDeFerias.Comunicacao.Respostas.Funcionario;

    public record RespostaDashboardPedidosFuncionarioJson(string Id, string DataPedido, string DataInicio, string DataFim, int Dias, Enum.Status Status);
