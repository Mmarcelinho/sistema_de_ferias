using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Api.Filtros.UsuarioLogado;

public class UsuarioAutenticadoAttribute<TEntidade> : AuthorizeAttribute, IAsyncAuthorizationFilter where TEntidade : Domain.Entidades.Usuario
{
    private readonly TokenController _tokenController;

    private readonly IUsuarioReadOnlyRepositorio<TEntidade> _repositorio;

    public UsuarioAutenticadoAttribute(TokenController tokenController, IUsuarioReadOnlyRepositorio<TEntidade> repositorio)
    {
        _tokenController = tokenController;
        _repositorio = repositorio;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenNaRequisicao(context);
            var emailUsuario = _tokenController.RecuperarEmail(token);

            var usuario = await _repositorio.RecuperarPorEmail(emailUsuario);

            if (usuario is null)
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
