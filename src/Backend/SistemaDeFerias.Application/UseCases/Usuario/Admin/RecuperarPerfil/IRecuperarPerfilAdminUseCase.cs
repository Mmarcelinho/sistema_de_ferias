namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.RecuperarPerfil;

    public interface IRecuperarPerfilAdminUseCase
    {
        Task<RespostaPerfilAdminJson> Executar();
    }