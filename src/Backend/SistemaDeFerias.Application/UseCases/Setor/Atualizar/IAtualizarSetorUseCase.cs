namespace SistemaDeFerias.Application.UseCases.Setor.Atualizar;

    public interface IAtualizarSetorUseCase
    {
        Task Executar(long id, RequisicaoSetorJson requisicao);
    }
