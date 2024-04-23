namespace UseCases.Test.Usuario.Funcionario.Registrar;

public class RegistrarFuncionarioUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();

        var useCase = CriarUseCase();

        var resposta = await useCase.Executar(requisicao);

        resposta.Should().NotBeNull();
        resposta.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Email_Ja_Registrado()
    {
        var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();

        var useCase = CriarUseCase(requisicao.Email);

        Func<Task> acao = async () => { await useCase.Executar(requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.EMAIL_JA_REGISTRADO));
    }

    [Fact]
    public async Task Validar_Erro_Email_Vazio()
    {
        var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();
        var requisicaoSemEmail = requisicao with { Email = string.Empty };

        var useCase = CriarUseCase();

        Func<Task> acao = async () => { await useCase.Executar(requisicaoSemEmail); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO));
    }

    private static RegistrarFuncionarioUseCase CriarUseCase(string email = "")
    {
        var mapper = MapperBuilder.Instancia();
        var repositorio = FuncionarioWriteOnlyRepositorioBuilder.Instancia().Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var token = TokenControllerBuilder.Instancia();
        var repositorioReadOnly = FuncionarioReadOnlyRepositorioBuilder.Instancia().ExisteUsuarioComEmail(email).Construir();

        return new RegistrarFuncionarioUseCase(repositorio, mapper, unidadeDeTrabalho, encriptador, token, repositorioReadOnly);
    }
}
