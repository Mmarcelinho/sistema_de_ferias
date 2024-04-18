using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;

public class LoginAdminUseCase : LoginUsuarioUseCase<Domain.Entidades.Admin>, ILoginAdminUseCase
{
    public LoginAdminUseCase(IUsuarioReadOnlyRepositorio<Domain.Entidades.Admin> usuarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController) : base(usuarioReadOnlyRepositorio, encriptadorDeSenha, tokenController)
    { }
}
