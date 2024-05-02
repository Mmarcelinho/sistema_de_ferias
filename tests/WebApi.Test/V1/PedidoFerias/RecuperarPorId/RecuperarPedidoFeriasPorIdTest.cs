namespace WebApi.Test.V1.PedidoFerias.RecuperarPorId;

public class RecuperarPedidoFeriasPorIdTest : ControllerBase
{
    private const string METODO = "pedidoferias";

    private const string METODOLOGIN = "funcionario";

    private readonly SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioComPedido;

    private readonly string _senhaFuncionarioComPedido;

    public RecuperarPedidoFeriasPorIdTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionarioComPedido = factory.RecuperarFuncionarioComPedido();
        _senhaFuncionarioComPedido = factory.RecuperarSenhaFuncionarioComPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var pedidoFeriasId = await GetPedidoId(token, METODOLOGIN);

        var resposta = await GetRequest($"{METODO}/{pedidoFeriasId}", token);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("id").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataPedido").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataInicio").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataFim").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dias").GetInt32().Should().BeGreaterThan(0);
    }


    [Fact]
    public async Task Validar_Erro_PedidoFerias_Inexistente()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var pedidoFeriasId = 0;

        var resposta = await GetRequest($"{METODO}/{pedidoFeriasId}", token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("PEDIDO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}