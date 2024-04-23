namespace UseCases.Test.Login.Funcionario.FazerLogin;

public class LoginFuncionarioUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var resposta = await useCase.Executar(new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
        {
            Email = funcionario.Email,
            Senha = senha
        });

        resposta.Should().NotBeNull();
        resposta.Nome.Should().Be(funcionario.Nome);
        resposta.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Senha_Invalida()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        Func<Task> acao = async () =>
        {
            await useCase.Executar(
                new SistemaDeFerias.Comunicacao.Requisicoes.Usuario.RequisicaoLoginUsuarioJson
                {
                    Email = funcionario.Email,
                    Senha = "SenhaIncorreta"
                });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>().Where(exception => exception.Message.Equals(ResourceMensagensDeErro.LOGIN_INVALIDO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Invalido()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

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
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

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

    private static LoginFuncionarioUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Funcionario funcionario)
    {
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var token = TokenControllerBuilder.Instancia();

        var repositorioReadOnly = FuncionarioReadOnlyRepositorioBuilder.Instancia().RecuperarPorEmailSenha(funcionario).Construir();

        return new LoginFuncionarioUseCase(repositorioReadOnly, encriptador, token);
    }
}
