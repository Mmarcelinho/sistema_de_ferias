namespace SistemaDeFerias.Application.UseCases.Usuario.RecuperarPerfil;

    public interface IRecuperarPerfilUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task<RespostaPerfilUsuarioJson> Executar();
    }