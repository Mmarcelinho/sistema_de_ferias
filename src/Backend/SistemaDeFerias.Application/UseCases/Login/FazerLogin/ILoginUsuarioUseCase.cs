namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin;

    public interface ILoginUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task<Comunicacao.Respostas.Usuario.RespostaLoginUsuarioJson> Executar(RequisicaoLoginUsuarioJson requisicao);
    }
