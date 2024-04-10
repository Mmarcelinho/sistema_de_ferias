namespace SistemaDeFerias.Domain.Repositorios.Setor;

    public interface ISetorWriteOnlyRepositorio
    {
       Task Registrar(Entidades.Setor setor);

        Task Deletar(long setorId);  
    }
