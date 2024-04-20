namespace Utilitario.Testes.Repositorios.Admin;

public class AdminReadOnlyRepositorioBuilder
{
    private static AdminReadOnlyRepositorioBuilder _instance;

    private readonly Mock<IAdminReadOnlyRepositorio> _repositorio;

    private AdminReadOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IAdminReadOnlyRepositorio>();
        }
    }

    public static AdminReadOnlyRepositorioBuilder Instancia()
    {
        _instance = new AdminReadOnlyRepositorioBuilder();
        return _instance;
    }

    public AdminReadOnlyRepositorioBuilder ExisteUsuarioComEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
            _repositorio.Setup(i => i.ExisteUsuarioComEmail(email)).ReturnsAsync(true);

        return this;
    }

    public AdminReadOnlyRepositorioBuilder RecuperarPorEmailSenha(SistemaDeFerias.Domain.Entidades.Admin admin)
    {
        _repositorio.Setup(i => i.RecuperarPorEmailSenha(admin.Email, admin.Senha)).ReturnsAsync(admin);

        return this;
    }

    public IAdminReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}
