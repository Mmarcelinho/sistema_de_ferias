using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Application.Servicos.UsuarioLogado;

public class UsuarioLogado<TEntidade> : IUsuarioLogado<TEntidade> where TEntidade : Domain.Entidades.Usuario
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly TokenController _tokenController;

    private readonly IUsuarioReadOnlyRepositorio<TEntidade> _repositorio;

    public UsuarioLogado(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IUsuarioReadOnlyRepositorio<TEntidade> repositorio)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _repositorio = repositorio;
    }

    public async Task<TEntidade> RecuperarUsuario()
    {
        var authorizationHeader = "Authorization";
        var authorization = _httpContextAccessor.HttpContext.Request.Headers[$"{authorizationHeader}"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var emailUsuario = _tokenController.RecuperarEmail(token);

        var usuario = await _repositorio.RecuperarPorEmail(emailUsuario);

        return usuario;
    }
}
