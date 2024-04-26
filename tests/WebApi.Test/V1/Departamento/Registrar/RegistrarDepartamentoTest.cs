using Utilitario.Testes.Requisicoes.Departamento;

namespace WebApi.Test.V1.Departamento.Registrar;

public class RegistrarDepartamentoTest : ControllerBase
{
    private const string METODO = "departamento";

    private const string METODOLOGIN = "admin";

    private SistemaDeFerias.Domain.Entidades.Admin _adminSemPedido;

    private string _senhaAdminSemPedido;

    public RegistrarDepartamentoTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _adminSemPedido = factory.RecuperarAdminSemPedido();
        _senhaAdminSemPedido = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var requisicao = RequisicaoDepartamentoBuilder.Construir();

        var resposta = await PostRequest(METODO, requisicao,  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("id").GetString().Should().NotBeNullOrWhiteSpace();
        responseData.RootElement.GetProperty("nome").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Nome_EmBranco()
    {
        var token = await Login(METODOLOGIN, _adminSemPedido.Email, _senhaAdminSemPedido);

        var requisicao = RequisicaoDepartamentoBuilder.Construir();
        var requisicaoSemNome = requisicao with { Nome = string.Empty };

        var resposta = await PostRequest(METODO, requisicaoSemNome,  token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("NOME_DO_DEPARTAMENTO_EMBRANCO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}