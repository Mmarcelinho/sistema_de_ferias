using SistemaDeFerias.Application.UseCases.Usuario.RecuperarPerfil;

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
        services.AddScoped<IUsuarioLogado<Domain.Entidades.Funcionario>, UsuarioLogado<Domain.Entidades.Funcionario>>();
        services.AddScoped<IUsuarioLogado<Domain.Entidades.Admin>, UsuarioLogado<Domain.Entidades.Admin>>();
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
        services.AddScoped<IRegistrarSetorUseCase, RegistrarSetorUseCase>();
        services.AddScoped<IAtualizarSetorUseCase, AtualizarSetorUseCase>();
        services.AddScoped<IRecuperarSetorPorIdUseCase, RecuperarSetorPorIdUseCase>();
        services.AddScoped<IDeletarSetorUseCase, DeletarSetorUseCase>();
        services.AddScoped<IRecuperarSetorPorNomeUseCase, RecuperarSetorPorNomeUseCase>();
        services.AddScoped<IRecuperarTodosSetoresUseCase, RecuperarTodosSetoresUseCase>();

        services.AddScoped<IRegistrarDepartamentoUseCase, RegistrarDepartamentoUseCase>();
        services.AddScoped<IAtualizarDepartamentoUseCase, AtualizarDepartamentoUseCase>();
        services.AddScoped<IRecuperarDepartamentoPorIdUseCase, RecuperarDepartamentoPorIdUseCase>();
        services.AddScoped<IDeletarDepartamentoUseCase, DeletarDepartamentoUseCase>();
        services.AddScoped<IRecuperarDepartamentoPorNomeUseCase, RecuperarDepartamentoPorNomeUseCase>();
        services.AddScoped<IRecuperarTodosDepartamentosUseCase, RecuperarTodosDepartamentosUseCase>();

        services.AddScoped<ILoginUsuarioUseCase<Domain.Entidades.Funcionario>, LoginUsuarioUseCase<Domain.Entidades.Funcionario>>();
        services.AddScoped<ILoginUsuarioUseCase<Domain.Entidades.Admin>, LoginUsuarioUseCase<Domain.Entidades.Admin>>();
        services.AddScoped<IAlterarSenhaUsuarioUseCase<Domain.Entidades.Funcionario>, AlterarSenhaUsuarioUseCase<Domain.Entidades.Funcionario>>();
        services.AddScoped<IAlterarSenhaUsuarioUseCase<Domain.Entidades.Admin>, AlterarSenhaUsuarioUseCase<Domain.Entidades.Admin>>();
        services.AddScoped<IRecuperarPerfilUsuarioUseCase<Domain.Entidades.Funcionario>, RecuperarPerfilUsuarioUseCase<Domain.Entidades.Funcionario>>();
        services.AddScoped<IRecuperarPerfilUsuarioUseCase<Domain.Entidades.Admin>, RecuperarPerfilUsuarioUseCase<Domain.Entidades.Admin>>();

        services.AddScoped<ILoginFuncionarioUseCase, LoginFuncionarioUseCase>();
        services.AddScoped<IRegistrarFuncionarioUseCase, RegistrarFuncionarioUseCase>();
        services.AddScoped<IRecuperarPerfilFuncionarioUseCase, RecuperarPerfilFuncionarioUseCase>();
        services.AddScoped<IAlterarSenhaFuncionarioUseCase, AlterarSenhaFuncionarioUseCase>();
        services.AddScoped<IPedidosFuncionarioDashboardUseCase, PedidosFuncionarioDashboardUseCase>();

        services.AddScoped<ILoginAdminUseCase, LoginAdminUseCase>();
        services.AddScoped<IRegistrarAdminUseCase, RegistrarAdminUseCase>();
        services.AddScoped<IRecuperarPerfilAdminUseCase, RecuperarPerfilAdminUseCase>();
        services.AddScoped<IAlterarSenhaAdminUseCase, AlterarSenhaAdminUseCase>();
        services.AddScoped<IPedidosAdminDashboardUseCase, PedidosAdminDashboardUseCase>();

        services.AddScoped<IRegistrarPedidoFeriasUseCase, RegistrarPedidoFeriasUseCase>();
        services.AddScoped<IRecuperarPedidoFeriasPorIdUseCase, RecuperarPedidoFeriasPorIdUseCase>();
        services.AddScoped<IAnalisarPedidoFeriasUseCase, AnalisarPedidoFeriasUseCase>();
        services.AddScoped<IAtualizarPedidoFeriasUseCase, AtualizarPedidoFeriasUseCase>();
        services.AddScoped<IDeletarPedidoFeriasUseCase, DeletarPedidoFeriasUseCase>();
    }
}
