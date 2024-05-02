namespace WebApi.Test.V1.Departamento.Deletar;

public class DeletarDepartamentoTest : ControllerBase
{
    private const string METODO = "departamento";

    private const string METODOLOGIN = "admin";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private readonly string _senhaAdminSemPedido;

    public DeletarDepartamentoTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var departamentoId = "1";

        var resposta = await DeleteRequest($"{METODO}/{departamentoId}",  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var respostaDepartamentoId = await GetRequest($"{METODO}/{departamentoId}",  token);

        respostaDepartamentoId.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await respostaDepartamentoId.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("DEPARTAMENTO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Departamento_Inexistente()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var departamentoId = "0";

        var resposta = await DeleteRequest($"{METODO}/{departamentoId}",  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("DEPARTAMENTO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}