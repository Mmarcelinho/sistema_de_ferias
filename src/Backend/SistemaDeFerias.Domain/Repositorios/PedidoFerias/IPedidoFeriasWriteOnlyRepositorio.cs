namespace SistemaDeFerias.Domain.Repositorios.PedidoFerias;

public interface IPedidoFeriasWriteOnlyRepositorio
{
    Task Registrar(Entidades.PedidoFerias pedido);
    Task Deletar(long pedidoId);
}
