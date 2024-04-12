namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarPorId;

    public interface IRecuperarSetorPorIdUseCase
    {
        Task<RespostaSetorJson> Executar(long id);
    }
