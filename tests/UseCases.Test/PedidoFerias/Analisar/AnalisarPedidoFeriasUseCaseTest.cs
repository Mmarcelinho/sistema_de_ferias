namespace UseCases.Test.PedidoFerias.Analisar;

public class AnalisarPedidoFeriasUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(admin, funcionario, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();
        var requisicaoStatusAprovado = requisicao with { Status = SistemaDeFerias.Comunicacao.Enum.Status.Aprovado };

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicaoStatusAprovado); };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Status_Ja_Negado()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Negado;

        var useCase = CriarUseCase(admin, funcionario, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();
        var requisicaoStatusAprovado = requisicao with { Status = SistemaDeFerias.Comunicacao.Enum.Status.Aprovado };

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicaoStatusAprovado); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_NEGADO));
    }

    [Fact]
    public async Task Validar_Status_Ja_Aprovado()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Aprovado;

        var useCase = CriarUseCase(admin, funcionario, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();
        var requisicaoStatusNegado = requisicao with { Status = SistemaDeFerias.Comunicacao.Enum.Status.Negado };

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicaoStatusNegado); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_APROVADO));
    }

    [Fact]
    public async Task Validar_Status_Pendente_Invalido()
    {
        (var admin, _) = AdminBuilder.Construir();
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(admin, funcionario, pedido);

        var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();
        var requisicaoStatusPendente = requisicao with { Status = SistemaDeFerias.Comunicacao.Enum.Status.Pendente };

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id, requisicaoStatusPendente); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.STATUS_DA_SOLICITACAO_INVALIDO));
    }

     private static AnalisarPedidoFeriasUseCase CriarUseCase(Admin admin, Funcionario funcionario, SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        var usuarioLogado = AdminLogadoBuilder.Instancia().RecuperarUsuario(admin).Construir();
        var mapper = MapperBuilder.Instancia();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var repositorioUpdate = PedidoFeriasUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(pedido).Construir();
        var repositorioFuncionarioUpdate = FuncionarioUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(funcionario).Construir();

        return new AnalisarPedidoFeriasUseCase(mapper, unidadeDeTrabalho, usuarioLogado, repositorioUpdate, repositorioFuncionarioUpdate);
    }
}
