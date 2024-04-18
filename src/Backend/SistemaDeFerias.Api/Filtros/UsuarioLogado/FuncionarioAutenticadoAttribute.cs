using SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

namespace SistemaDeFerias.Api.Filtros.UsuarioLogado;

public class FuncionarioAutenticadoAttribute : UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>
{
    private readonly TokenController _tokenController;

    private readonly UsuarioRepositorio<Domain.Entidades.Funcionario> _repositorio;

    public FuncionarioAutenticadoAttribute(TokenController tokenController, UsuarioRepositorio<Domain.Entidades.Funcionario> repositorio) : base(tokenController, repositorio)
    { }
}
