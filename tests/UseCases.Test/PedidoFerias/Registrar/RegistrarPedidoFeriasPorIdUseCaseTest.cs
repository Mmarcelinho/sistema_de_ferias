namespace UseCases.Test.PedidoFerias.Registrar;

public class RegistrarPedidoFeriasUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        funcionario.DataEntrada = DateTime.Now.AddYears(-1);

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
        var resposta = await useCase.Executar(requisicao);

        resposta.DataInicio.Should().Be(requisicao.DataInicio.ToString());
        resposta.Dias.Should().Be(requisicao.Dias);
    }

    [Fact]
    public async Task Validar_Sucesso_Funcionario_UltimaFerias()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        funcionario.DataEntrada = DateTime.Now.AddYears(-2);
        funcionario.DataUltimaFerias = DateTime.Now.AddYears(-1);

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
        var resposta = await useCase.Executar(requisicao);

        resposta.DataInicio.Should().Be(requisicao.DataInicio.ToString());
        resposta.Dias.Should().Be(requisicao.Dias);
    }

    [Fact]
    public async Task Validar_Funcionario_Nao_Elegivel()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        funcionario.DataEntrada = DateTime.Now;

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        Func<Task> acao = async () => { await useCase.Executar(requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.FUNCIONARIO_NAO_ELEGIVEL_PARA_FERIAS));
    }

    [Fact]
    public async Task Validar_Funcionario_Nao_Elegivel_Ultima_Ferias()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        funcionario.DataEntrada = DateTime.Now.AddYears(-2);
        funcionario.DataUltimaFerias = DateTime.Now;

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        Func<Task> acao = async () => { await useCase.Executar(requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.FUNCIONARIO_NAO_ELEGIVEL_PARA_FERIAS));
    }

    [Fact]
    public async Task Validar_Quantidade_Dias_Invalido()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        funcionario.DataEntrada = DateTime.Now.AddYears(-1);

        var useCase = CriarUseCase(funcionario);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
        var requisicaoDiasInvalido = requisicao with { Dias = 0 };

        Func<Task> acao = async () => { await useCase.Executar(requisicaoDiasInvalido); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.QTD_DIAS_DO_PEDIDOFERIAS));
    }


    private static RegistrarPedidoFeriasUseCase CriarUseCase(
        Funcionario funcionario)
    {
        var usuarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();
        var mapper = MapperBuilder.Instancia();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var repositorioWrite = PedidoFeriasWriteOnlyRepositorioBuilder.Instancia().Construir();

        return new RegistrarPedidoFeriasUseCase(mapper, unidadeDeTrabalho, usuarioLogado, repositorioWrite);
    }
}
