namespace SistemaDeFerias.Domain.Repositorios.Departamento;

    public interface IDepartamentoUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.Departamento departamento);

        Task<Entidades.Departamento> RecuperarPorId(long departamentoId);
    }
