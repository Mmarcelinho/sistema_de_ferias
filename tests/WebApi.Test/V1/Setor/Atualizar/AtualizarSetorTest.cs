namespace WebApi.Test.V1.Setor.Atualizar;

public class AtualizarSetorTest : ControllerBase
{
    private const string METODO = "setor";

    private const string METODOLOGIN = "admin";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private readonly string _senhaAdminSemPedido;

    public AtualizarSetorTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoSetorBuilder.Construir();

        var setorId = "1";

        var resposta = await PutRequest($"{METODO}/{setorId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var responseData = await GetSetorPorId(setorId, token);

        responseData.RootElement.GetProperty("id").GetString().Should().Be(setorId);
        responseData.RootElement.GetProperty("nome").GetString().Should().Be(requisicao.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Nome_Vazio()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoSetorBuilder.Construir();

        var requisicaoSemNome = requisicao with { Nome = string.Empty };

        var setorId = "1";

        var resposta = await PutRequest($"{METODO}/{setorId}", requisicaoSemNome, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("NOME_DO_SETOR_EMBRANCO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Setor_Inexistente()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoSetorBuilder.Construir();

        var setorId = "0";

        var resposta = await PutRequest($"{METODO}/{setorId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("SETOR_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    private async Task<JsonDocument> GetSetorPorId(string setorId, string token)
    {
        var resposta = await GetRequest($"{METODO}/{setorId}", token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        return await JsonDocument.ParseAsync(respostaBody);
    }
}