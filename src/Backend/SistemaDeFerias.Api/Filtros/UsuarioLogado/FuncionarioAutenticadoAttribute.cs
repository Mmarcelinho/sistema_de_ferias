namespace SistemaDeFerias.Api.Filtros.UsuarioLogado;

public class FuncionarioAutenticadoAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly TokenController _tokenController;

    private readonly IFuncionarioReadOnlyRepositorio _repositorio;

    public FuncionarioAutenticadoAttribute(TokenController tokenController, IFuncionarioReadOnlyRepositorio repositorio)
    {
        _tokenController = tokenController;
        _repositorio = repositorio;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenNaRequisicao(context);
            var emailFuncionario = _tokenController.RecuperarEmail(token);

            var funcionario = await _repositorio.RecuperarPorEmail(emailFuncionario);

            if (funcionario is null)
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
        var authorizationHeader = "Authorization";
        var authorization = context.HttpContext.Request.Headers[$"{authorizationHeader}"].ToString();

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
