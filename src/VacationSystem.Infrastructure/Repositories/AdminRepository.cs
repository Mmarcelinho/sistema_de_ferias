using Microsoft.EntityFrameworkCore;
using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Infrastructure.Repositories.Shared;

namespace VacationSystem.Infrastructure.Repositories;

public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
{
    public AdminRepository(Context context) : base(context) { }
}

