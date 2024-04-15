namespace SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;

public class FuncionarioLogado : IFuncionarioLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    private readonly TokenController _tokenController;

    private IFuncionarioReadOnlyRepositorio _repositorio;

    public FuncionarioLogado(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IFuncionarioReadOnlyRepositorio repositorio)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _repositorio = repositorio;
    }
    
    public async Task<Domain.Entidades.Funcionario> RecuperarFuncionario()
    {
        var authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var emailFuncionario = _tokenController.RecuperarEmail(token);

        var funcionario = await _repositorio.RecuperarPorEmail(emailFuncionario);

        return funcionario;
    }
}
