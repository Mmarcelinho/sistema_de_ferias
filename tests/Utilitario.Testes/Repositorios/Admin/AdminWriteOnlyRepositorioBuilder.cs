namespace Utilitario.Testes.Domain.Repositorios.Admin;

public class AdminWriteOnlyRepositorioBuilder
{
    private static AdminWriteOnlyRepositorioBuilder _instance;
    private readonly Mock<IAdminWriteOnlyRepositorio> _repositorio;

    private AdminWriteOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IAdminWriteOnlyRepositorio>();
        }
    }

    public static AdminWriteOnlyRepositorioBuilder Instancia()
    {
        _instance = new AdminWriteOnlyRepositorioBuilder();
        return _instance;
    }

    public IAdminWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}