namespace Utilitario.Testes.Repositorios.Admin;

public class AdminUpdateOnlyRepositorioBuilder
{
    private static AdminUpdateOnlyRepositorioBuilder _instance;
    private readonly Mock<IAdminUpdateOnlyRepositorio> _repositorio;

    private AdminUpdateOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IAdminUpdateOnlyRepositorio>();
        }
    }

    public static AdminUpdateOnlyRepositorioBuilder Instancia()
    {
        _instance = new AdminUpdateOnlyRepositorioBuilder();
        return _instance;
    }

    public AdminUpdateOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Admin admin)
    {
        _repositorio.Setup(c => c.RecuperarPorId(admin.Id)).ReturnsAsync(admin);

        return this;
    }

    public IAdminUpdateOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}
