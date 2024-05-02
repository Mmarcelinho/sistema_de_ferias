namespace WebApi.Test.V1.Admin.RecuperarPerfil;

public class RecuperarAdminTest : ControllerBase
{
    private const string METODO = "admin";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _admin;

    private readonly string _senha;
    
    public RecuperarAdminTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _admin = factory.RecuperarAdminSemPedido();
        _senha = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODO, _admin.Email, _senha);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().Be(_admin.Nome);
        responseData.RootElement.GetProperty("email").GetString().Should().Be(_admin.Email);
        responseData.RootElement.GetProperty("telefone").GetString().Should().Be(_admin.Telefone);
    }
}
