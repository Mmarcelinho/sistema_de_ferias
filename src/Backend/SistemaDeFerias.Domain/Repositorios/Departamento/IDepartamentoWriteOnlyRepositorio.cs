namespace SistemaDeFerias.Domain.Repositorios.Departamento;

    public interface IDepartamentoWriteOnlyRepositorio
    {
       Task Registrar(Entidades.Departamento departamento);

        Task Deletar(long departamentoId); 
    }
