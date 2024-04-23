namespace UseCases.Test.Usuario.Admin.AlterarSenha;

public class AlterarSenhaAdminUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

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
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

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
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

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
        (var admin, var senha) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir(tamanhoSenha);
        var requisicaoSenhaAtual = requisicao with { SenhaAtual = senha };

        Func<Task> acao = async () =>
        {
            await useCase.Executar(requisicaoSenhaAtual);
        };


        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
    }


    private static AlterarSenhaAdminUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Admin admin)
    {
        var encriptador = EncriptadorDeSenhaBuilder.Instancia();
        var unidadeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var repositorio = AdminUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(admin).Construir();
        var adminLogado = AdminLogadoBuilder.Instancia().RecuperarUsuario(admin).Construir();

        return new AlterarSenhaAdminUseCase(repositorio, adminLogado, encriptador, unidadeTrabalho);
    }
}
