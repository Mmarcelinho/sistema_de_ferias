namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Atualizar;

    public interface IAtualizarPedidoFeriasUseCase
    {
        Task Executar(long id, RequisicaoSolicitarPedidoFeriasJson requisicao);
    }
