using Utilitario.Testes.Requisicoes.PedidoFerias;

namespace WebApi.Test.V1.PedidoFerias.Atualizar;

public class AtualizarPedidoFeriasTest : ControllerBase
{
    private const string METODOGET = "pedidoferias";

    private const string METODOATUALIZAR = "pedidoferias/atualizar";

    private const string METODOLOGIN = "funcionario";

    private SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioComPedido;

    private string _senhaFuncionarioComPedido;

    public AtualizarPedidoFeriasTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionarioComPedido = factory.RecuperarFuncionarioComPedido();
        _senhaFuncionarioComPedido = factory.RecuperarSenhaFuncionarioComPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);
        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        var pedidoFeriasId = await GetPedidoId(token, METODOLOGIN);

        var resposta = await PutRequest($"{METODOATUALIZAR}/{pedidoFeriasId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var responseData = await GetPedidoFeriasPorId(pedidoFeriasId, token);

        responseData.RootElement.GetProperty("id").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataPedido").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataInicio").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dataFim").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("dias").GetInt32().Should().Be(requisicao.Dias);
    }

    [Fact]
    public async Task Validar_Erro_Quantidade_Dias_Vazio()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);
        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        var requisicaoDiasVazio = requisicao with { Dias = 0 };

        var pedidoFeriasId = await GetPedidoId(token, METODOLOGIN);

        var resposta = await PutRequest($"{METODOATUALIZAR}/{pedidoFeriasId}", requisicaoDiasVazio, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("QTD_DIAS_DO_PEDIDOFERIAS");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_PedidoFerias_Inexistente()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);

        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        var pedidoFeriasId = 0;

        var resposta = await PutRequest($"{METODOATUALIZAR}/{pedidoFeriasId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("PEDIDO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    private async Task<JsonDocument> GetPedidoFeriasPorId(string pedidoFeriasId, string token)
    {
        var resposta = await GetRequest($"{METODOGET}/{pedidoFeriasId}", token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        return await JsonDocument.ParseAsync(respostaBody);
    }
}