namespace SistemaDeFerias.Application.Servicos.UsuarioLogado.Admin;

    public interface IAdminLogado
    {
        Task<Domain.Entidades.Admin> RecuperarAdmin();
    }
