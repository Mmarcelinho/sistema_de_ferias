namespace SistemaDeFerias.Application.UseCases.Setor.Atualizar;

    public interface IAtualizarSetorUseCase
    {
        Task Executar(long Id, RequisicaoSetorJson requisicao);
    }
