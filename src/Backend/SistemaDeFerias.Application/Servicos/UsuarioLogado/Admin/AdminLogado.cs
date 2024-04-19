namespace SistemaDeFerias.Application.Servicos.UsuarioLogado.Admin;

public class AdminLogado : UsuarioLogado<Domain.Entidades.Admin>, IAdminLogado
{
    public AdminLogado(
        IHttpContextAccessor httpContextAccessor, 
        TokenController tokenController, 
        IUsuarioReadOnlyRepositorio<Domain.Entidades.Admin> repositorio) : 
        base(httpContextAccessor, tokenController, repositorio)
        { }
}