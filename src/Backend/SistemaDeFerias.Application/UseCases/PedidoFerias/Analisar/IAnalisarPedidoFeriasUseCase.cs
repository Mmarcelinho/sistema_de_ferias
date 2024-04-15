namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;

    public interface IAnalisarPedidoFeriasUseCase
    {
        Task Executar(long id, RequisicaoAnalisarPedidoFeriasJson requisicao);
    }
