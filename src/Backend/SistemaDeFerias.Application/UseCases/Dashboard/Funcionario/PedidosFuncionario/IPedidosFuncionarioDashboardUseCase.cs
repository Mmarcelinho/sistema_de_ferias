namespace SistemaDeFerias.Application.UseCases.Dashboard.Funcionario.PedidosFuncionario;

    public interface IPedidosFuncionarioDashboardUseCase
    {
        Task<RespostaDashboardFuncionarioJson> Executar();
    }
