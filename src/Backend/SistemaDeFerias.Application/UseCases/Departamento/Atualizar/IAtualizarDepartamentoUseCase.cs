namespace SistemaDeFerias.Application.UseCases.Departamento.Atualizar;

    public interface IAtualizarDepartamentoUseCase
    {
        Task Executar(long id, RequisicaoDepartamentoJson requisicao);
    }
