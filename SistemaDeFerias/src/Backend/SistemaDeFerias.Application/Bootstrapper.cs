using SistemaDeFerias.Application.UseCases.Setor.Atualizar;
using SistemaDeFerias.Application.UseCases.Setor.Deletar;
using SistemaDeFerias.Application.UseCases.Setor.RecuperarPorId;

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
    }
}
