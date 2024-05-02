namespace WebApi.Test.V1.Usuario.Funcionario.Login.FazerLogin;

public class LoginFuncionarioTest : ControllerBase
{
    private const string METODOLOGIN = "login/funcionario";

    private readonly SistemaDeFerias.Domain.Entidades.Funcionario _funcionario;

    private readonly string _senha;

    public LoginFuncionarioTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    {
        _funcionario = factory.RecuperarFuncionarioSemPedido();
        _senha = factory.RecuperarSenhaFuncionarioSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var requisicao = new RequisicaoLoginUsuarioJson
        {
            Email = _funcionario.Email,
            Senha = _senha
        };

        var resposta = await PostRequest(METODOLOGIN, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().NotBeNullOrWhiteSpace().And.Be(_funcionario.Nome);
        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Senha_Invalido()
    {
        var requisicao = new RequisicaoLoginUsuarioJson
        {
            Email = _funcionario.Email,
            Senha = "senhaInvalida"
        };

        var resposta = await PostRequest(METODOLOGIN, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("LOGIN_INVALIDO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Email_Invalido()
    {
        var requisicao = new RequisicaoLoginUsuarioJson
        {
            Email = "email@invalido.com",
            Senha = _senha
        };

        var resposta = await PostRequest(METODOLOGIN, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("LOGIN_INVALIDO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }

    [Fact]
    public async Task Validar_Erro_Email__Senha_Invalido()
    {
        var requisicao = new RequisicaoLoginUsuarioJson
        {
            Email = "email@invalido.com",
            Senha = "senhaInvalida"
        };

        var resposta = await PostRequest(METODOLOGIN, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("LOGIN_INVALIDO");
        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(mensagemEsperada));
    }
}
