using Utilitario.Testes.Requisicoes.PedidoFerias;

namespace WebApi.Test.V1.PedidoFerias.Registrar;

public class RegistrarPedidoFeriasTest : ControllerBase
{
    private const string METODO = "pedidoferias";

    private const string METODOLOGIN = "funcionario";

    private SistemaDeFerias.Domain.Entidades.Funcionario _funcionarioComPedido;

    private string _senhaFuncionarioComPedido;

    public RegistrarPedidoFeriasTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionarioComPedido = factory.RecuperarFuncionarioComPedido();
        _senhaFuncionarioComPedido = factory.RecuperarSenhaFuncionarioComPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionarioComPedido.Email, _senhaFuncionarioComPedido);
        var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

        var resposta = await PostRequest(METODO, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

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

        var resposta = await PostRequest(METODO, requisicaoDiasVazio, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("QTD_DIAS_DO_PEDIDOFERIAS");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}