using Microsoft.EntityFrameworkCore;
using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Infrastructure.Repositories.Shared;

namespace VacationSystem.Infrastructure.Repositories;

public class PedidoFeriasRepository : RepositoryBase<PedidoFerias>, IPedidoFeriasRepository
{
    public PedidoFeriasRepository(Context context) : base(context) { }
        public override async Task<IEnumerable<PedidoFerias>> ObterTodosAsync()
    {
        var listaObjeto = await Context.PedidosFerias
        .Include(x => x.Funcionario)
        .Include(x => x.Admin).ToListAsync();
        return listaObjeto ?? Enumerable.Empty<PedidoFerias>();
    }

    public override async Task<PedidoFerias?> ObterPorIdAsync(int id) => await Context.PedidosFerias
    .Include(x => x.Funcionario)
    .Include(x => x.Admin).FirstOrDefaultAsync();
}

