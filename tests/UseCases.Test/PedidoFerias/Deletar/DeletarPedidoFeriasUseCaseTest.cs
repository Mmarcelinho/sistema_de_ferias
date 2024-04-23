namespace UseCases.Test.PedidoFerias.Deletar;

public class DeletarPedidoFeriasUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        Func<Task> acao = async () => { await useCase.Executar(pedido.Id); };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Nao_Existe()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

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

    private static DeletarPedidoFeriasUseCase CriarUseCase(
        Funcionario funcionario,
        SistemaDeFerias.Domain.Entidades.PedidoFerias pedido)
    {
        var usuarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();
        var repositorioWrite = PedidoFeriasWriteOnlyRepositorioBuilder.Instancia().Construir();
        var repositorioRead = PedidoFeriasReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(pedido).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new DeletarPedidoFeriasUseCase(unidadeDeTrabalho, usuarioLogado, repositorioWrite, repositorioRead);
    }
}
