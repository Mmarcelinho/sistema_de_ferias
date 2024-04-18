namespace SistemaDeFerias.Domain.Repositorios.Usuario;

    public interface IUsuarioReadOnlyRepositorio<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task<bool> ExisteUsuarioComEmail(string email);
        
        Task<TEntidade> RecuperarPorId(long id);

        Task<TEntidade> RecuperarPorEmailSenha(string email, string senha);

        Task<TEntidade> RecuperarPorEmail(string email);
    }
