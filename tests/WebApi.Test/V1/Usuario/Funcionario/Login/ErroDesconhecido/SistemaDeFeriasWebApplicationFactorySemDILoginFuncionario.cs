namespace WebApi.Test.V1.Usuario.Funcionario.Login.ErroDesconhecido;

public class SistemaDeFeriasWebApplicationFactorySemDILoginFuncionario<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
        .ConfigureServices(services =>
        {
            var descritor = services.SingleOrDefault(d => d.ServiceType == typeof(SistemaDeFeriasContext));
            if (descritor is not null)
                services.Remove(descritor);

            var useCaseLoginFuncionario = services.SingleOrDefault(d => d.ServiceType == typeof(SistemaDeFerias.Application.UseCases.Login.FazerLogin.ILoginUsuarioUseCase<SistemaDeFerias.Domain.Entidades.Funcionario>));

            if(useCaseLoginFuncionario is not null)
            services.Remove(useCaseLoginFuncionario);
            
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
        });

    }

}