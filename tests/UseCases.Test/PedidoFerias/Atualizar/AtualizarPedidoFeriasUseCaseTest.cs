namespace UseCases.Test.PedidoFerias.Atualizar;

public class AtualizarPedidoFeriasUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        await useCase.Executar(pedido.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicao); };

        await acao.Should().NotThrowAsync();
        
        pedido.DataInicio.Should().Be(requisicao.DataInicio);
        pedido.Dias.Should().Be(requisicao.Dias);
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Nao_Existe()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
        
        Func<Task> acao = async () => { await useCase.Executar(0, requisicao); };

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

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        var resposta = useCase.Executar(pedido.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO));
    }

    private static AtualizarPedidoFeriasUseCase CriarUseCase(
        Funcionario funcionario,
        SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        var usuarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();
        var mapper = MapperBuilder.Instancia();
        var repositorioUpdate = PedidoFeriasUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(pedido).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new AtualizarPedidoFeriasUseCase(mapper, unidadeDeTrabalho, usuarioLogado, repositorioUpdate);
    }
}
