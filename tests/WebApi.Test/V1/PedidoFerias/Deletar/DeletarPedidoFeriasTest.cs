namespace WebApi.Test.V1.PedidoFerias.Deletar;

public class DeletarPedidoFeriasTest : ControllerBase
{
    private const string METODO = "pedidoferias";

    private const string METODOLOGIN = "funcionario";

    private SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioComPedido;

    private string _senhaFuncionarioComPedido;

    public DeletarPedidoFeriasTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionarioComPedido = factory.RecuperarFuncionarioComPedido();
        _senhaFuncionarioComPedido = factory.RecuperarSenhaFuncionarioComPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var pedidoFeriasId = await GetPedidoId(token, METODOLOGIN);

        var resposta = await DeleteRequest($"{METODO}/{pedidoFeriasId}", token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var respostaPedidoId = await GetRequest($"{METODO}/{pedidoFeriasId}", token);

        respostaPedidoId.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await respostaPedidoId.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("PEDIDO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }


    [Fact]
    public async Task Validar_Erro_PedidoFerias_Inexistente()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var pedidoFeriasId = 0;

        var resposta = await DeleteRequest($"{METODO}/{pedidoFeriasId}", token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("PEDIDO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}