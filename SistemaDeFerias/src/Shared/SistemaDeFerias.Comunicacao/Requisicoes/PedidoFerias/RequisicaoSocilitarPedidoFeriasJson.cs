namespace SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

    public record RequisicaoSolicitarPedidoFeriasJson(long FuncionarioId, DateTime DataInicio, int Dias);
