namespace Utilitario.Testes.Domain.RepositorioDepartamento;

public class DepartamentoWriteOnlyRepositorioBuilder
{
    private static DepartamentoWriteOnlyRepositorioBuilder _instance;
    private readonly Mock<IDepartamentoWriteOnlyRepositorio> _repositorio;

    private DepartamentoWriteOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IDepartamentoWriteOnlyRepositorio>();
        }
    }

    public static DepartamentoWriteOnlyRepositorioBuilder Instancia()
    {
        _instance = new DepartamentoWriteOnlyRepositorioBuilder();
        return _instance;
    }

    public IDepartamentoWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}