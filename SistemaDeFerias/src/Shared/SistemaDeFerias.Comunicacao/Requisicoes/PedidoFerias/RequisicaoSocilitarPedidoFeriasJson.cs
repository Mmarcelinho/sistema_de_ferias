namespace SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

    public record RequisicaoSolicitarPedidoFeriasJson(long FuncionarioId, DateOnly DataInicio, int Dias);
