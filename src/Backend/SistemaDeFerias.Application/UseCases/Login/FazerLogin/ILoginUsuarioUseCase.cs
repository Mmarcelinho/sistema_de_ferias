namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin;

    public interface ILoginUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task<RespostaLoginUsuarioJson> Executar(RequisicaoLoginUsuarioJson requisicao);
    }
