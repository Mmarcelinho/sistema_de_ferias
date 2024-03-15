using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using VacationSystem.Infrastructure.Repositories;


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

        return services;
    }
}
