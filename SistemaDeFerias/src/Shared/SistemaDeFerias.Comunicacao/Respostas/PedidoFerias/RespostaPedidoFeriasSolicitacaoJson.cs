namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

    public record RespostaPedidoFeriasSolicitacaoJson(long FuncionarioId, DateTime DataPedido, DateTime DataInicio, DateTime DataFim, int Dias);