namespace UseCases.Test.PedidoFerias.Analisar;

public class AnalisarPedidoFeriasUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(admin, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicao); };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Status_Ja_Aprovado()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Aprovado;

        var useCase = CriarUseCase(admin, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_APROVADO));
    }

    [Fact]
    public async Task Validar_Status_Ja_Negado()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Negado;

        var useCase = CriarUseCase(admin, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_NEGADO));
    }

     private static AnalisarPedidoFeriasUseCase CriarUseCase(Admin admin, SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        var usuarioLogado = AdminLogadoBuilder.Instancia().RecuperarUsuario(admin).Construir();
        var mapper = MapperBuilder.Instancia();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var repositorioUpdate = PedidoFeriasUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(pedido).Construir();
        var repositorioFuncionarioUpdate = FuncionarioUpdateOnlyRepositorioBuilder.Instancia().Construir();

        return new AnalisarPedidoFeriasUseCase(mapper, unidadeDeTrabalho, usuarioLogado, repositorioUpdate, repositorioFuncionarioUpdate);
    }
}
