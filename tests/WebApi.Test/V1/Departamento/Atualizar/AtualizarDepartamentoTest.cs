using Utilitario.Testes.Requisicoes.Departamento;

namespace WebApi.Test.V1.Departamento.Atualizar;

public class AtualizarDepartamentoTest : ControllerBase
{
    private const string METODO = "departamento";

    private const string METODOLOGIN = "admin";

    private SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private string _senhaAdminSemPedido;

    public AtualizarDepartamentoTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoDepartamentoBuilder.Construir();

        var departamentoId = "1";

        var resposta = await PutRequest($"{METODO}/{departamentoId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var responseData = await GetDepartamentoPorId(departamentoId, token);

        responseData.RootElement.GetProperty("id").GetString().Should().Be(departamentoId);
        responseData.RootElement.GetProperty("nome").GetString().Should().Be(requisicao.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Nome_Vazio()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoDepartamentoBuilder.Construir();

        var requisicaoSemNome = requisicao with { Nome = string.Empty };

        var departamentoId = "1";

        var resposta = await PutRequest($"{METODO}/{departamentoId}", requisicaoSemNome, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("NOME_DO_DEPARTAMENTO_EMBRANCO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Departamento_Inexistente()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);
        var requisicao = RequisicaoDepartamentoBuilder.Construir();

        var departamentoId = "0";

        var resposta = await PutRequest($"{METODO}/{departamentoId}", requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("DEPARTAMENTO_NAO_ENCONTRADO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    private async Task<JsonDocument> GetDepartamentoPorId(string departamentoId, string token)
    {
        var resposta = await GetRequest($"{METODO}/{departamentoId}", token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        return await JsonDocument.ParseAsync(respostaBody);
    }
}