namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorId;

    public interface IRecuperarDepartamentoPorIdUseCase
    {
        Task<RespostaDepartamentoJson> Executar(long id);
    }
