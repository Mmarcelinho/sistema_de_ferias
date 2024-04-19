namespace SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;

public class FuncionarioLogado : UsuarioLogado<Domain.Entidades.Funcionario>, IFuncionarioLogado
{
    public FuncionarioLogado(
        IHttpContextAccessor httpContextAccessor, 
        TokenController tokenController, 
        IUsuarioReadOnlyRepositorio<Domain.Entidades.Funcionario> repositorio) : 
        base(httpContextAccessor, tokenController, repositorio)
    { }
}
