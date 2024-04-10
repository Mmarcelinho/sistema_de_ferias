namespace SistemaDeFerias.Domain.Repositorios.Departamento;

    public interface IDepartamentoReadOnlyRepositorio
    {
        Task<Entidades.Departamento> RecuperarPorId(long departamentoId);

        Task<Entidades.Departamento> RecuperarPorNome(string nome);
    }
