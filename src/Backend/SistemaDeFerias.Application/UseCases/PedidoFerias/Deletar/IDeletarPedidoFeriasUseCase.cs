namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Deletar;

    public interface IDeletarPedidoFeriasUseCase
    {
        Task Executar(long id);
    }
