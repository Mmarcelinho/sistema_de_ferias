namespace WebApi.Test.V1.Dashboard;

public class AdminDashboardTest : ControllerBase
{
    private const string METODO = "dashboard/admin";

    private const string METODOLOGIN = "admin";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _adminComPedido;

    private readonly string _senhaAdminComPedido;

    private readonly SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private readonly string _senhaAdminSemPedido;

    public AdminDashboardTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminComPedido = factory.RecuperarAdminComPedido();
        _senhaAdminComPedido = factory.RecuperarSenhaAdminComPedido();

        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminComPedido.Email, _senhaAdminComPedido);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("pedidos").GetArrayLength().Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Inexistente()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
