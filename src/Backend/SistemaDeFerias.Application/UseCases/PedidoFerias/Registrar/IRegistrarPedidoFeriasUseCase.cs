namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;

    public interface IRegistrarPedidoFeriasUseCase
    {
        Task<RespostaPedidoFeriasSolicitacaoJson> Executar(RequisicaoSolicitarPedidoFeriasJson requisicao);
    }
