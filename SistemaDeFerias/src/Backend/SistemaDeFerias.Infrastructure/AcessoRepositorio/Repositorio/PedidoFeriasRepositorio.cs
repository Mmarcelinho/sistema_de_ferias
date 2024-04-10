
namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class PedidoFeriasRepositorio : IPedidoFeriasReadOnlyRepositorio, IPedidoFeriasWriteOnlyRepositorio, IPedidoFeriasUpdateOnlyRepositorio
{
    private readonly SistemaDeFeriasContext _contexto;

    public PedidoFeriasRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

    async Task<PedidoFerias> IPedidoFeriasReadOnlyRepositorio.RecuperarPorId(long pedidoId)
    {
        return await _contexto.PedidoFerias.AsNoTracking()
        .Include(p => p.Funcionario)
        .Include(p => p.Admin)
        .FirstOrDefaultAsync(p => p.Id == pedidoId);
    }

    async Task<PedidoFerias> IPedidoFeriasUpdateOnlyRepositorio.RecuperarPorId(long pedidoId)
    {
        return await _contexto.PedidoFerias.AsNoTracking()
        .Include(p => p.Funcionario)
        .Include(p => p.Admin)
        .FirstOrDefaultAsync(p => p.Id == pedidoId);
    }

    public async Task<IList<PedidoFerias>> RecuperarTodasDoAdmin(long adminId)
    {
        return await _contexto.PedidoFerias.AsNoTracking()
        .Include(p => p.Funcionario)
        .Include(p => p.Admin)
        .Where(p => p.AdminId == adminId).ToListAsync();
    }

    public async Task<IList<PedidoFerias>> RecuperarTodasDoFuncionario(long funcionarioId)
    {
        return await _contexto.PedidoFerias.AsNoTracking()
        .Include(p => p.Funcionario)
        .Include(p => p.Admin)
        .Where(p => p.FuncionarioId == funcionarioId).ToListAsync();
    }

    public async Task Registrar(PedidoFerias pedido) =>
    await _contexto.PedidoFerias.AddAsync(pedido);

    public void Atualizar(PedidoFerias pedido) =>
    _contexto.PedidoFerias.Update(pedido);

    public async Task Deletar(long pedidoId)
    {
        var pedido = await _contexto.PedidoFerias.FirstOrDefaultAsync(p => p.Id == pedidoId);

        _contexto.PedidoFerias.Remove(pedido);
    }
}
