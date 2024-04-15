namespace SistemaDeFerias.Domain.Repositorios.Admin;

    public interface IAdminWriteOnlyRepositorio
    {
        Task Adicionar(Entidades.Admin admin);
    }
