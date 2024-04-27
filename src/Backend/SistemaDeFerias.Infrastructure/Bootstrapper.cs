using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AdicionarContexto(services, configuration);
            AdicionarUnidadeDeTrabalho(services);
            AdicionarRepositorios(services);
        }

        private static void AdicionarContexto(IServiceCollection services, IConfiguration configuration)
        {
            _ = bool.TryParse(configuration.GetSection("Configuracoes:BancoDeDadosInMemory").Value, out bool bancoDeDadosInMemory);

            if(!bancoDeDadosInMemory)
            {
                var connectionString = configuration.GetConexaoCompleta();

            services.AddDbContext<SistemaDeFeriasContext>(dbContextoOpcoes =>
            {
                dbContextoOpcoes.UseSqlServer(connectionString);
            });
            }
        }

        private static void AdicionarUnidadeDeTrabalho(IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }

        private static void AdicionarRepositorios(IServiceCollection services)
        {
            services.AddScoped<ISetorReadOnlyRepositorio, SetorRepositorio>();
            services.AddScoped<ISetorWriteOnlyRepositorio, SetorRepositorio>();
            services.AddScoped<ISetorUpdateOnlyRepositorio, SetorRepositorio>();
            
            services.AddScoped<IDepartamentoReadOnlyRepositorio, DepartamentoRepositorio>();
            services.AddScoped<IDepartamentoWriteOnlyRepositorio, DepartamentoRepositorio>();
            services.AddScoped<IDepartamentoUpdateOnlyRepositorio, DepartamentoRepositorio>();

            services.AddScoped<IUsuarioReadOnlyRepositorio<Admin>, UsuarioRepositorio<Admin>>();
            services.AddScoped<IUsuarioWriteOnlyRepositorio<Admin>, UsuarioRepositorio<Admin>>();
            services.AddScoped<IUsuarioUpdateOnlyRepositorio<Admin>, UsuarioRepositorio<Admin>>();

            services.AddScoped<IAdminReadOnlyRepositorio, AdminRepositorio>();
            services.AddScoped<IAdminWriteOnlyRepositorio, AdminRepositorio>();
            services.AddScoped<IAdminUpdateOnlyRepositorio, AdminRepositorio>();

            services.AddScoped<IUsuarioReadOnlyRepositorio<Funcionario>, UsuarioRepositorio<Funcionario>>();
            services.AddScoped<IUsuarioWriteOnlyRepositorio<Funcionario>, UsuarioRepositorio<Funcionario>>();
            services.AddScoped<IUsuarioUpdateOnlyRepositorio<Funcionario>, UsuarioRepositorio<Funcionario>>();

            services.AddScoped<IFuncionarioReadOnlyRepositorio, FuncionarioRepositorio>();
            services.AddScoped<IFuncionarioWriteOnlyRepositorio, FuncionarioRepositorio>();
            services.AddScoped<IFuncionarioUpdateOnlyRepositorio, FuncionarioRepositorio>();

            services.AddScoped<IPedidoFeriasReadOnlyRepositorio, PedidoFeriasRepositorio>();
            services.AddScoped<IPedidoFeriasWriteOnlyRepositorio, PedidoFeriasRepositorio>();
            services.AddScoped<IPedidoFeriasUpdateOnlyRepositorio, PedidoFeriasRepositorio>();
        }
    }
}