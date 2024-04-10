namespace SistemaDeFerias.Domain.Repositorios.PedidoFerias;

public interface IPedidoFeriasReadOnlyRepositorio
{
    Task<IList<Entidades.PedidoFerias>> RecuperarTodasDoFuncionario(long funcionarioId);

    Task<IList<Entidades.PedidoFerias>> RecuperarTodasDoAdmin(long adminId);
    
    Task<Entidades.PedidoFerias> RecuperarPorId(long pedidoId);
}
