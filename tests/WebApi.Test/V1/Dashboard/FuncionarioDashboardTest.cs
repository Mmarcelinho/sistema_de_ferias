namespace WebApi.Test.V1.Dashboard;

public class FuncionarioDashboardTest : ControllerBase
{
    private const string METODO = "dashboard/funcionario";

    private const string METODOLOGIN = "funcionario";

    private readonly SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioComPedido;

    private readonly string _senhaFuncionarioComPedido;

    private readonly SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioSemPedido;

    private readonly string _senhaFuncionarioSemPedido;

    public FuncionarioDashboardTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionarioComPedido = factory.RecuperarFuncionarioComPedido();
        _senhaFuncionarioComPedido = factory.RecuperarSenhaFuncionarioComPedido();

        _funcionarioSemPedido = factory.RecuperarFuncionarioSemPedido();
        _senhaFuncionarioSemPedido = factory.RecuperarSenhaFuncionarioSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("pedidos").GetArrayLength().Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Validar_Erro_Pedido_Inexistente()
    {
        var token = await Login(METODOLOGIN, _funcionarioSemPedido.Email, _senhaFuncionarioSemPedido);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
