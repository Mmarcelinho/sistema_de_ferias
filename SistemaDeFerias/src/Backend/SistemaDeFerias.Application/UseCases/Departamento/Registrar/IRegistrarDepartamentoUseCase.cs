namespace SistemaDeFerias.Application.UseCases.Departamento.Registrar;

    public interface IRegistrarDepartamentoUseCase
    {
        Task<RespostaDepartamentoJson> Executar(RequisicaoDepartamentoJson requisicao);
    }
