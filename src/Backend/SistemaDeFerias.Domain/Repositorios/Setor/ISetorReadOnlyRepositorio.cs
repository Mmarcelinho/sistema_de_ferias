namespace SistemaDeFerias.Domain.Repositorios.Setor;

    public interface ISetorReadOnlyRepositorio
    {
      Task<Entidades.Setor> RecuperarPorId(long setorId);

        Task<Entidades.Setor> RecuperarPorNome(string nome);  
    }
