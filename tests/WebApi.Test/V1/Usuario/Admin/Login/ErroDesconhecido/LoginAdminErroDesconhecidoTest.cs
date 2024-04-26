namespace WebApi.Test.V1.Usuario.Admin.Login.ErroDesconhecido;

public class LoginAdminErroDesconhecidoTest : IClassFixture<SistemaDeFeriasWebApplicationFactorySemDILoginAdmin<Program>>
{
    private const string METODOLOGIN = "login/admin";

    private readonly HttpClient _client;

    public LoginAdminErroDesconhecidoTest(SistemaDeFeriasWebApplicationFactorySemDILoginAdmin<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Validar_Erro_Desconhecido()
    {
        var requisicao = new RequisicaoLoginUsuarioJson();

        var resposta = await PostRequest(METODOLOGIN, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("ERRO_DESCONHECIDO");

        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    private async Task<HttpResponseMessage> PostRequest(string metodo, object body)
    {
        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PostAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }
}
