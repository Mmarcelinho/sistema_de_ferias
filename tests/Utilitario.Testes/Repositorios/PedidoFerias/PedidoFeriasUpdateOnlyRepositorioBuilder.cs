namespace Utilitario.Testes.Repositorios.PedidoFerias;

public class PedidoFeriasUpdateOnlyRepositorioBuilder
{
    private static PedidoFeriasUpdateOnlyRepositorioBuilder _instance;
    private readonly Mock<IPedidoFeriasUpdateOnlyRepositorio> _repositorio;

    private PedidoFeriasUpdateOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IPedidoFeriasUpdateOnlyRepositorio>();
        }
    }

    public static PedidoFeriasUpdateOnlyRepositorioBuilder Instancia()
    {
        _instance = new PedidoFeriasUpdateOnlyRepositorioBuilder();
        return _instance;
    }

    public PedidoFeriasUpdateOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        _repositorio.Setup(r => r.RecuperarPorId(pedido.Id)).ReturnsAsync(pedido);
            
        return this;
    }

    public IPedidoFeriasUpdateOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
