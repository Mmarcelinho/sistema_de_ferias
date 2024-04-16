namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorNome;

    public interface IRecuperarDepartamentoPorNomeUseCase
    {
        Task<RespostaDepartamentoJson> Executar(string nome);
    }
