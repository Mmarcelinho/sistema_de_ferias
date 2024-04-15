namespace SistemaDeFerias.Application.UseCases.PedidoFerias.RecuperarPorId;

    public interface IRecuperarPedidoFeriasPorIdUseCase
    {
        Task<RespostaPedidoFeriasJson> Executar(long id);
    }
