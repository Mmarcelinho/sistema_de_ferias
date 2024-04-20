namespace SistemaDeFerias.Domain.Repositorios.Usuario;

    public interface IUsuarioWriteOnlyRepositorio<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task Adicionar(TEntidade entidade);
    }
