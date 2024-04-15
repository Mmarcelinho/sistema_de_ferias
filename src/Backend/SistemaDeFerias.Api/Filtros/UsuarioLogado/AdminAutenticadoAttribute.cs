namespace SistemaDeFerias.Api.Filtros.UsuarioLogado;

public class AdminAutenticadoAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly TokenController _tokenController;

    private readonly IAdminReadOnlyRepositorio _repositorio;

    public AdminAutenticadoAttribute(TokenController tokenController, IAdminReadOnlyRepositorio repositorio)
    {
        _tokenController = tokenController;
        _repositorio = repositorio;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenNaRequisicao(context);
            var emailAdmin = _tokenController.RecuperarEmail(token);

            var admin = await _repositorio.RecuperarPorEmail(emailAdmin);

            if (admin is null)
                throw new SistemaDeFeriasException(string.Empty);
        }
        catch (SecurityTokenExpiredException)
        {
            TokenExpirado(context);
        }
        catch
        {
            UsuarioSemPermissao(context);
        }
    }
    private static string TokenNaRequisicao(AuthorizationFilterContext context)
    {
        var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(authorization))
            throw new SistemaDeFeriasException(string.Empty);

        return authorization["Bearer".Length..].Trim();
    }

    private static void TokenExpirado(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new RespostaErroJson(ResourceMensagensDeErro.TOKEN_EXPIRADO));
    }

    private static void UsuarioSemPermissao(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new RespostaErroJson(ResourceMensagensDeErro.USUARIO_SEM_PERMISSAO));
    }
}
