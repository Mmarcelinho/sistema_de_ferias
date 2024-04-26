namespace WebApi.Test.V1;

public class ControllerBase : IClassFixture<SistemaDeFeriasWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ControllerBase(SistemaDeFeriasWebApplicationFactory<Program> factory)
    => _client = factory.CreateClient();


    protected async Task<HttpResponseMessage> PostRequest(string metodo, object body, string token = "")
    {
        AutorizarRequisicao(token);

        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PostAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    protected async Task<HttpResponseMessage> PutRequest(string metodo, object body, string token = "")
    {
        AutorizarRequisicao(token);

        var jsonString = JsonConvert.SerializeObject(body);

        return await _client.PutAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }

    protected async Task<HttpResponseMessage> GetRequest(string metodo, string token = "")
    {
        AutorizarRequisicao(token);

        return await _client.GetAsync(metodo);
    }

    protected async Task<HttpResponseMessage> DeleteRequest(string metodo, string token = "")
    {
        AutorizarRequisicao(token);

        return await _client.DeleteAsync(metodo);
    }


    protected async Task<string> Login(string metodo, string email, string senha)
    {
        var requisicao = new RequisicaoLoginUsuarioJson
        {
            Email = email,
            Senha = senha
        };

        var resposta = await PostRequest($"login/{metodo}", requisicao);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        return responseData.RootElement.GetProperty("token").GetString();
    }

    protected async Task<string> GetPedidoId(string token, string usuario)
    {
        var resposta = await GetRequest($"dashboard/{usuario}", token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        return responseData.RootElement.GetProperty("pedidos").EnumerateArray().First().GetProperty("id").GetString();
    }

    private void AutorizarRequisicao(string token)
    {
        if (!string.IsNullOrWhiteSpace(token) && !_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}