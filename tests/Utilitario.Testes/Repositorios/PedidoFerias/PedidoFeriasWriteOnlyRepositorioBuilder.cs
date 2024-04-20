namespace Utilitario.Testes.Domain.RepositorioPedidoFerias;

public class PedidoFeriasWriteOnlyRepositorioBuilder
{
    private static PedidoFeriasWriteOnlyRepositorioBuilder _instance;
    private readonly Mock<IPedidoFeriasWriteOnlyRepositorio> _repositorio;

    private PedidoFeriasWriteOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IPedidoFeriasWriteOnlyRepositorio>();
        }
    }

    public static PedidoFeriasWriteOnlyRepositorioBuilder Instancia()
    {
        _instance = new PedidoFeriasWriteOnlyRepositorioBuilder();
        return _instance;
    }

    public IPedidoFeriasWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}