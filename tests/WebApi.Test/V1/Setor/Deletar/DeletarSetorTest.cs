namespace WebApi.Test.V1.Setor.Deletar;

public class DeletarSetorTest : ControllerBase
{
    private const string METODO = "setor";

    private const string METODOLOGIN = "admin";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private readonly string _senhaAdminSemPedido;

    public DeletarSetorTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var setorId = "1";

        var resposta = await DeleteRequest($"{METODO}/{setorId}",  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var respostaSetorId = await GetRequest($"{METODO}/{setorId}",  token);

        respostaSetorId.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await respostaSetorId.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("SETOR_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Setor_Inexistente()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var setorId = "0";

        var resposta = await DeleteRequest($"{METODO}/{setorId}",  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("SETOR_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}