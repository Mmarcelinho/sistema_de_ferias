namespace WebApi.Test.V1.Funcionario.RecuperarPerfil;

public class RecuperarFuncionarioTest : ControllerBase
{
    private const string METODO = "funcionario";

    private readonly SistemaDeFerias.Domain.Entidades.Funcionario _funcionario;

    private readonly string _senha;
    
    public RecuperarFuncionarioTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _funcionario = factory.RecuperarFuncionarioSemPedido();
        _senha = factory.RecuperarSenhaFuncionarioSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODO, _funcionario.Email, _senha);

        var resposta = await GetRequest(METODO, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().Be(_funcionario.Nome);
        responseData.RootElement.GetProperty("email").GetString().Should().Be(_funcionario.Email);
        responseData.RootElement.GetProperty("telefone").GetString().Should().Be(_funcionario.Telefone);
    }
}
