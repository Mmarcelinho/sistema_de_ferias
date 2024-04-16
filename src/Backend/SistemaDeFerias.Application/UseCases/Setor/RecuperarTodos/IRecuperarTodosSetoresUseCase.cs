namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarTodos;

    public interface IRecuperarTodosSetoresUseCase
    {
        Task<RespostaSetorListJson> Executar();
    }
