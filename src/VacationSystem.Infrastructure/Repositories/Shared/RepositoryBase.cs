using Microsoft.EntityFrameworkCore;
using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Interfaces.Repositories.Shared;
using VacationSystem.Infrastructure.Data;

namespace VacationSystem.Infrastructure.Repositories.Shared;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    protected Context Context;
    DbSet<TEntity> DbSet;

    public RepositoryBase(Context context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        var listaObjeto = await DbSet.AsNoTracking().ToListAsync();
        return listaObjeto ?? Enumerable.Empty<TEntity>();
    }

    public virtual async Task<TEntity?> ObterPorIdAsync(int id) => await DbSet.FindAsync(id);

    public virtual async Task<object> AdicionarAsync(TEntity objeto)
    {
        await DbSet.AddAsync(objeto);
        return objeto.Id;
    }

    public virtual void AtualizarAsync(TEntity objeto)
    {
        if (objeto is null)
            throw new ArgumentNullException(nameof(objeto));

        DbSet.Update(objeto);
    }

    public virtual async Task RemoverPorIdAsync(int id)
    {
        var objeto = await ObterPorIdAsync(id);
        if (objeto == null)
            throw new Exception("O registro não existe na base de dados.");

        DbSet.Remove(objeto);
    }
}

