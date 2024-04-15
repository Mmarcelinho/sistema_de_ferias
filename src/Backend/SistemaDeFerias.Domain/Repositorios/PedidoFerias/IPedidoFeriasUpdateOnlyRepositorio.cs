namespace SistemaDeFerias.Domain.Repositorios.PedidoFerias;

    public interface IPedidoFeriasUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.PedidoFerias pedido);
        Task<Entidades.PedidoFerias> RecuperarPorId(long pedidoId);
    
    }
