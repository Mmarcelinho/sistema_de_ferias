namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;

    public interface IAnalisarPedidoFeriasUseCase
    {
        Task<RespostaPedidoFeriasAnalisadoJson> Executar(long id, RequisicaoAnalisarPedidoFeriasJson requisicao);
    }
