namespace WebApi.Test;

public class SistemaDeFeriasWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private Admin _adminComPedido;

    private string _senhaAdminComPedido;

    private Admin _adminSemPedido;

    private string _senhaAdminSemPedido;

    private Funcionario _funcionarioComPedido;

    private string _senhaFuncionarioComPedido;

    private Funcionario _funcionarioSemPedido;

    private string _senhaFuncionarioSemPedido;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
        .ConfigureServices(services =>
        {
            var descritor = services.SingleOrDefault(d => d.ServiceType == typeof(SistemaDeFeriasContext));
            if (descritor is not null)
                services.Remove(descritor);

            var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            services.AddDbContext<SistemaDeFeriasContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(provider);
            });

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var scopeService = scope.ServiceProvider;

            var database = scopeService.GetRequiredService<SistemaDeFeriasContext>();

            database.Database.EnsureDeleted();

            (_adminComPedido, _senhaAdminComPedido) = ContextSeedInMemory.SeedAdminComPedido(database);

            (_adminSemPedido, _senhaAdminSemPedido) = ContextSeedInMemory.SeedAdminSemPedido(database);

            (_funcionarioComPedido, _senhaFuncionarioComPedido) = ContextSeedInMemory.SeedFuncionarioComPedido(database);

            (_funcionarioSemPedido, _senhaFuncionarioSemPedido) = ContextSeedInMemory.SeedFuncionarioSemPedido(database);

            ContextSeedInMemory.SeedSetorEDepartamento(database);
        });
    }

    public Admin RecuperarAdminComPedido() => _adminComPedido;

    public Admin RecuperarAdminSemPedido() => _adminSemPedido;

    public string RecuperarSenhaAdminComPedido() => _senhaAdminComPedido;

    public string RecuperarSenhaAdminSemPedido() => _senhaAdminSemPedido;

    public Funcionario RecuperarFuncionarioComPedido() => _funcionarioComPedido;

    public Funcionario RecuperarFuncionarioSemPedido() => _funcionarioSemPedido;

    public string RecuperarSenhaFuncionarioComPedido() => _senhaFuncionarioComPedido;

    public string RecuperarSenhaFuncionarioSemPedido() => _senhaFuncionarioSemPedido;

}
