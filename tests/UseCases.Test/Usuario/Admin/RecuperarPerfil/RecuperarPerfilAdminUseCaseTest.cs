namespace UseCases.Test.Usuario.Admin.RecuperarPerfil;

    public class RecuperarPerfilAdminUseCaseTest
    {
        [Fact]
    public async Task Validar_Sucesso()
    {
        (var admin, _) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        var resposta = await useCase.Executar();

        resposta.Should().NotBeNull();
        resposta.Nome.Should().Be(admin.Nome);
        resposta.Email.Should().Be(admin.Email);
        resposta.Telefone.Should().Be(admin.Telefone);
    }

    private static RecuperarPerfilAdminUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Admin admin)
    {
        var mapper = MapperBuilder.Instancia();        
        var adminLogado = AdminLogadoBuilder.Instancia().RecuperarUsuario(admin).Construir();

        return new RecuperarPerfilAdminUseCase(mapper, adminLogado);
    }
    }
