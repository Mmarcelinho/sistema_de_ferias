namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarTodos;

    public interface IRecuperarTodosDepartamentosUseCase
    {
        Task<RespostaDepartamentoListJson> Executar();
    }
