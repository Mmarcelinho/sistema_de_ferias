namespace Utilitario.Testes.Repositorios.PedidoFerias;

public class PedidoFeriasReadOnlyRepositorioBuilder
{
    private static PedidoFeriasReadOnlyRepositorioBuilder _instance;
    private readonly Mock<IPedidoFeriasReadOnlyRepositorio> _repositorio;

    private PedidoFeriasReadOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IPedidoFeriasReadOnlyRepositorio>();
        }
    }

    public static PedidoFeriasReadOnlyRepositorioBuilder Instancia()
    {
        _instance = new PedidoFeriasReadOnlyRepositorioBuilder();
        return _instance;
    }

    public PedidoFeriasReadOnlyRepositorioBuilder RecuperarTodasDoAdmin(SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido is not null)
            _repositorio.Setup(r => r.RecuperarTodasDoAdmin((long)pedido.AdminId)).ReturnsAsync(new List<SistemaDeFerias.Domain.Entidades.PedidoFerias> { pedido });

        return this;
    }

    public PedidoFeriasReadOnlyRepositorioBuilder RecuperarTodasDoFuncionario(SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido is not null)
            _repositorio.Setup(r => r.RecuperarTodasDoFuncionario(pedido.FuncionarioId)).ReturnsAsync(new List<SistemaDeFerias.Domain.Entidades.PedidoFerias> { pedido });

        return this;
    }

    public PedidoFeriasReadOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        _repositorio.Setup(r => r.RecuperarPorId(pedido.Id)).ReturnsAsync(pedido);

        return this;
    }

    public IPedidoFeriasReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }    
}
