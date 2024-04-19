namespace SistemaDeFerias.Domain.Repositorios.Usuario;

    public interface IUsuarioUpdateOnlyRepositorio<TEntidade> where TEntidade : Domain.Entidades.Usuario
    { 
        void Atualizar(TEntidade entidade);

        Task<TEntidade> RecuperarPorId(long id);
    }
