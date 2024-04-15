namespace SistemaDeFerias.Infrastructure.AcessoRepositorio;

public class SistemaDeFeriasContext : DbContext
{
    public SistemaDeFeriasContext(DbContextOptions<SistemaDeFeriasContext> options) : base(options) { }

    public DbSet<Setor> Setores { get; set; }

    public DbSet<Departamento> Departamentos { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Funcionario> Funcionarios { get; set; }

    public DbSet<PedidoFerias> PedidoFerias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaDeFeriasContext).Assembly);
    }
}
