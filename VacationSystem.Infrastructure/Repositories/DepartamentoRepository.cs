using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Infrastructure.Repositories.Shared;

namespace VacationSystem.Infrastructure.Repositories;

public class DepartamentoRepository : RepositoryBase<Departamento>, IDepartamentoRepository
{
    public DepartamentoRepository(Context context) : base(context) { }
}

