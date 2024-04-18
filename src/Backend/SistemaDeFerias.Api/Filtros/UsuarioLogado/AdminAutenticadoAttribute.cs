using SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

namespace SistemaDeFerias.Api.Filtros.UsuarioLogado;

public class AdminAutenticadoAttribute : UsuarioAutenticadoAttribute<Domain.Entidades.Admin>
{
    private readonly TokenController _tokenController;

    private readonly UsuarioRepositorio<Domain.Entidades.Admin> _repositorio;

    public AdminAutenticadoAttribute(TokenController tokenController, UsuarioRepositorio<Domain.Entidades.Admin> repositorio) : base(tokenController, repositorio)
    { }
}
