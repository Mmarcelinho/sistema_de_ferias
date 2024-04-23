namespace UseCases.Test.Login.Admin.FazerLogin;

public class LoginAdminUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        var resposta = await useCase.Executar(new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
        {
            Email = admin.Email,
            Senha = senha
        });

        resposta.Should().NotBeNull();
        resposta.Nome.Should().Be(admin.Nome);
        resposta.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Senha_Invalida()
    {
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        Func<Task> acao = async () =>
        {
            await useCase.Executar(
                new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
                {
                    Email = admin.Email,
                    Senha = "SenhaIncorreta"
                });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>().Where(exception => exception.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Invalido()
    {
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        Func<Task> acao = async () =>
        {
            await useCase.Executar(
                new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
                {
                    Email = "emailIncorreto@teste.com",
                    Senha = senha
                });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>().Where(exception => exception.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Senha_Invalido()
    {
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        Func<Task> acao = async () =>
        {
            await useCase.Executar(
                new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
                {
                    Email = "emailIncorreto@teste.com",
                    Senha = "SenhaIncorreta"
                });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>().Where(exception => exception.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    private static LoginAdminUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Admin admin)
    {
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var token = TokenControllerBuilder.Instancia();

        var repositorioReadOnly = AdminReadOnlyRepositorioBuilder.Instancia().RecuperarPorEmailSenha(admin).Construir();

        return new LoginAdminUseCase(repositorioReadOnly, encriptador, token);
    }
}
