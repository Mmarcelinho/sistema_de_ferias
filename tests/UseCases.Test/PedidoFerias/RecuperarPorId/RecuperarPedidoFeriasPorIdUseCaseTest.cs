namespace UseCases.Test.PedidoFerias.RecuperarPorId;

public class RecuperarPedidoFeriasPorIdUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        var resposta = await useCase.Executar(pedido.Id);

        resposta.DataInicio.Should().Be(pedido.DataInicio.ToString());
        resposta.DataFim.Should().Be(pedido.DataFim.ToString());
        resposta.Dias.Should().Be(pedido.Dias);
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Nao_Existe()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        Func<Task> acao = async () => { await useCase.Executar(0); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO));
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Nao_Pertence_Usuario_Logado()
    {
        (var funcionario, var senha) = FuncionarioBuilder.Construir();
        (var funcionario2, var _) = FuncionarioBuilder.Construir();

        funcionario2.Id = 2;

        var pedido = PedidoFeriasBuilder.Construir(funcionario2.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO));
    }

    private static RecuperarPedidoFeriasPorIdUseCase CriarUseCase(
        Funcionario funcionario,
        SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        var usuarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = PedidoFeriasReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(pedido).Construir();

        return new RecuperarPedidoFeriasPorIdUseCase(mapper, usuarioLogado, repositorioRead);
    }
}
