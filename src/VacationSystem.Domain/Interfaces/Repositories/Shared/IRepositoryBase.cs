using VacationSystem.Domain.Entities.Shared;

namespace VacationSystem.Domain.Interfaces.Repositories.Shared;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<object> AdicionarAsync(TEntity objeto);
    void AtualizarAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}