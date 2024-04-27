namespace UseCases.Test.Usuario.Funcionario.AlterarSenha;

public class AlterarSenhaFuncionarioUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        var requisicaoSenhaAtual = requisicao with { SenhaAtual = senha };

        Func<Task> acao = async () =>
        {
            await useCase.Executar(requisicaoSenhaAtual);
        };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Erro_NovaSenhaEmBranco()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        var requisicaoNovaSenha = requisicao with { SenhaAtual = senha, NovaSenha = "" };

        Func<Task> acao = async () =>
        {
            await useCase.Executar(requisicaoNovaSenha);
        };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));
    }

    [Fact]
    public async Task Validar_Erro_SenhaAtual_Invalida()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        var requisicaoSenhaAtual = requisicao with { SenhaAtual = "SenhaInválida" };

        Func<Task> acao = async () =>
        {
            await useCase.Executar(requisicaoSenhaAtual);
        };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_ATUAL_INVALIDA));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Validar_Erro_SenhaAtual_Minimo_Caracteres(int tamanhoSenha)
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir(tamanhoSenha);
        var requisicaoSenhaAtual = requisicao with { SenhaAtual = senha };

        Func<Task> acao = async () =>
        {
            await useCase.Executar(requisicaoSenhaAtual);
        };


        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
    }


    private static AlterarSenhaFuncionarioUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Funcionario funcionario)
    {
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var unidadeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var repositorio = FuncionarioUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(funcionario).Construir();
        var funcionarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();

        return new AlterarSenhaFuncionarioUseCase(repositorio, funcionarioLogado, encriptador, unidadeTrabalho);
    }
}
