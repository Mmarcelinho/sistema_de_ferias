using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Repositories;
using VacationSystem.Domain.Interfaces.Services;
using VacationSystem.Application.Services;

namespace VacationSystem.IoC.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
      this IServiceCollection services,
      IConfiguration configuration)
    {
        var SqlConnection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<Context>(opt => opt.UseSqlServer(SqlConnection));

        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

        services.AddScoped<IAdminRepository, AdminRepository>();

        services.AddScoped<IPedidoFeriasRepository, PedidoFeriasRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

         services.AddScoped<IPedidoFeriasService, PedidoFeriasService>();

        return services;
    }
}
