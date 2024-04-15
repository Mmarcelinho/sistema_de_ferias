namespace SistemaDeFerias.Application.UseCases.Departamento.Atualizar;

    public interface IAtualizarDepartamentoUseCase
    {
        Task Executar(long Id, RequisicaoDepartamentoJson requisicao);
    }
