namespace SistemaDeFerias.Application.Servicos.UsuarioLogado;

    public interface IUsuarioLogado<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task<TEntidade> RecuperarUsuario();
    }
