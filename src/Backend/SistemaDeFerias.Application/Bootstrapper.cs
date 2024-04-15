namespace SistemaDeFerias.Application;

public static class Bootstrapper
{
    public static void AdicionarApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarChaveAdicionalSenha(services, configuration);
        AdicionarTokenJWT(services, configuration);
        AdicionarUseCases(services);
        AdicionarUsuarioLogado(services);
    }

    private static void AdicionarUsuarioLogado(IServiceCollection services)
    {
       services.AddScoped<IAdminLogado, AdminLogado>();
       services.AddScoped<IFuncionarioLogado, FuncionarioLogado>();
    }

    private static void AdicionarChaveAdicionalSenha(IServiceCollection services, IConfiguration configuration)
    {
         var section = configuration.GetRequiredSection("Configuracoes:Senha:ChaveAdicionalSenha");

         services.AddScoped(option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:Jwt:TempoVidaTokenMinutos");
        var sectionKey = configuration.GetRequiredSection("Configuracoes:Jwt:ChaveToken");
        
        services.AddScoped(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }

    private static void AdicionarUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistrarSetorUseCase,RegistrarSetorUseCase>();
        services.AddScoped<IAtualizarSetorUseCase,AtualizarSetorUseCase>();
        services.AddScoped<IRecuperarSetorPorIdUseCase, RecuperarSetorPorIdUseCase>();
        services.AddScoped<IDeletarSetorUseCase, DeletarSetorUseCase>();

        services.AddScoped<IRegistrarDepartamentoUseCase,RegistrarDepartamentoUseCase>();
        services.AddScoped<IAtualizarDepartamentoUseCase,AtualizarDepartamentoUseCase>();
        services.AddScoped<IRecuperarDepartamentoPorIdUseCase, RecuperarDepartamentoPorIdUseCase>();
        services.AddScoped<IDeletarDepartamentoUseCase, DeletarDepartamentoUseCase>();

        services.AddScoped<ILoginFuncionarioUseCase,LoginFuncionarioUseCase>();
        services.AddScoped<IRegistrarFuncionarioUseCase,RegistrarFuncionarioUseCase>();
        services.AddScoped<IRecuperarPerfilFuncionarioUseCase,RecuperarPerfilFuncionarioUseCase>();
        services.AddScoped<IAlterarSenhaFuncionarioUseCase,AlterarSenhaFuncionarioUseCase>();
        services.AddScoped<IPedidosFuncionarioDashboardUseCase,PedidosFuncionarioDashboardUseCase>();
        

        services.AddScoped<ILoginAdminUseCase,LoginAdminUseCase>();
        services.AddScoped<IRegistrarAdminUseCase,RegistrarAdminUseCase>();
        services.AddScoped<IRecuperarPerfilAdminUseCase,RecuperarPerfilAdminUseCase>();
        services.AddScoped<IAlterarSenhaAdminUseCase,AlterarSenhaAdminUseCase>();
        services.AddScoped<IPedidosAdminDashboardUseCase,PedidosAdminDashboardUseCase>();
        
        services.AddScoped<IRegistrarPedidoFeriasUseCase,RegistrarPedidoFeriasUseCase>();
        services.AddScoped<IAnalisarPedidoFeriasUseCase,AnalisarPedidoFeriasUseCase>();
        services.AddScoped<IAtualizarPedidoFeriasUseCase,AtualizarPedidoFeriasUseCase>();
    }
}
