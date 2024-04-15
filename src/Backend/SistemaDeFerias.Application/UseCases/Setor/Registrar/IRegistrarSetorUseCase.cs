namespace SistemaDeFerias.Application.UseCases.Setor.Registrar;

    public interface IRegistrarSetorUseCase
    {
        Task<RespostaSetorJson> Executar(RequisicaoSetorJson requisicao);
    }
