using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    { }

    public DbSet<Funcionario> Funcionarios { get; set; }

    public DbSet<Departamento> Departamentos { get; set; }

    public DbSet<Admin>Admins { get; set; }

    public DbSet<PedidoFerias> PedidosFerias { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}
