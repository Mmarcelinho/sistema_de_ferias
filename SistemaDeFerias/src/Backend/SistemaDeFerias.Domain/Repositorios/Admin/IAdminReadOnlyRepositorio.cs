namespace SistemaDeFerias.Domain.Repositorios.Admin;

    public interface IAdminReadOnlyRepositorio
    {
        Task<Entidades.Admin> RecuperarPorId(long adminId);

        Task<Entidades.Admin> RecuperarPorEmailSenha(string email, string senha);

        Task<Entidades.Admin> RecuperarPorEmail(string email);
    }
