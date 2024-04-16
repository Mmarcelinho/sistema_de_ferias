namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarPorNome;

    public interface IRecuperarSetorPorNomeUseCase
    {
        Task<RespostaSetorJson> Executar(string nome);
    }
