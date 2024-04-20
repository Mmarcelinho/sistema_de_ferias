namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.RecuperarPerfil;

public class RecuperarPerfilAdminUseCase : RecuperarPerfilUsuarioUseCase<Domain.Entidades.Admin>, IRecuperarPerfilAdminUseCase
{
    public RecuperarPerfilAdminUseCase(IMapper mapper, IUsuarioLogado<Domain.Entidades.Admin> usuarioLogado) : base(mapper, usuarioLogado)
    { }
}
