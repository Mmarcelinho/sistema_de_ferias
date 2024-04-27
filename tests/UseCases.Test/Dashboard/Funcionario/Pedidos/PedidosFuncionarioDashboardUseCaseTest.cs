namespace UseCases.Test.Dashboard.Funcionario.Pedidos;

public class PedidosFuncionarioDashboardUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, var _) = FuncionarioBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(funcionario.Id);

        var useCase = CriarUseCase(funcionario, pedido);

        var resposta = await useCase.Executar();

        resposta.Pedidos.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task Validar_Sucesso_Sem_Pedidos()
    {
        (var funcionario, var _) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var resposta = await useCase.Executar();

        resposta.Pedidos.Should().HaveCount(0);
    }

    private static PedidosFuncionarioDashboardUseCase CriarUseCase(
        SistemaDeFerias.Domain.Entidades.Funcionario funcionario,
        SistemaDeFerias.Domain.Entidades.PedidoFerias pedido = null)
    {
        var usuarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = PedidoFeriasReadOnlyRepositorioBuilder.Instancia().RecuperarTodasDoFuncionario(pedido).Construir();

        return new PedidosFuncionarioDashboardUseCase(repositorioRead, usuarioLogado, mapper);
    }

}
