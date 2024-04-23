namespace UseCases.Test.Dashboard.Admin.Pedidos;

public class PedidosAdminDashboardUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var pedidoId = 1;
        (var admin, var _) = AdminBuilder.Construir();

        var pedido = PedidoFeriasBuilder.Construir(pedidoId);
        pedido.AdminId = admin.Id;
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Aprovado;

        var useCase = CriarUseCase(admin, pedido);

        var resposta = await useCase.Executar();

        resposta.Pedidos.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task Validar_Sucesso_Sem_Pedidos()
    {
        (var admin, var _) = AdminBuilder.Construir();

        var useCase = CriarUseCase(admin);

        var resposta = await useCase.Executar();

        resposta.Pedidos.Should().HaveCount(0);
    }

    private static PedidosAdminDashboardUseCase CriarUseCase(
        SistemaDeFerias.Domain.Entidades.Admin admin,
        SistemaDeFerias.Domain.Entidades.PedidoFerias? pedido = null)
    {
        var usuarioLogado = AdminLogadoBuilder.Instancia().RecuperarUsuario(admin).Construir();
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = PedidoFeriasReadOnlyRepositorioBuilder.Instancia().RecuperarTodasDoAdmin(pedido).Construir();

        return new PedidosAdminDashboardUseCase(repositorioRead, usuarioLogado, mapper);
    }

}
