namespace SistemaDeFerias.Domain.Repositorios.Departamento;

    public interface IDepartamentoReadOnlyRepositorio
    {
        Task<IList<Entidades.Departamento>> RecuperarTodos();

        Task<Entidades.Departamento> RecuperarPorId(long departamentoId);

        Task<Entidades.Departamento> RecuperarPorNome(string nome);
    }
