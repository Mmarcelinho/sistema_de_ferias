namespace SistemaDeFerias.Application.UseCases.Dashboard.Admin.PedidosAdmin;

    public interface IPedidosAdminDashboardUseCase
    {
        Task<RespostaDashboardAdminJson> Executar();
    }
