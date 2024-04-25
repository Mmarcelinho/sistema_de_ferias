namespace WebApi.Test.V1.Funcionario.Registrar;

public class RegistrarFuncionarioTest : ControllerBase
{
    private const string METODOLOGIN = "admin";

    private const string METODO = "funcionario";

    private SistemaDeFerias.Domain.Entidades.Admin _admin;

    private string _senha;
    
    public RegistrarFuncionarioTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _admin = factory.RecuperarAdminSemPedido();
        _senha = factory.RecuperarSenhaAdminSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _admin.Email, _senha);

        var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();

        var resposta = await PostRequest(METODO, requisicao, token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Nome_Vazio()
    {
        var token = await Login(METODOLOGIN, _admin.Email, _senha);

        var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();

        var requisicaoSemNome = requisicao with { Nome = string.Empty };

        var resposta = await PostRequest(METODO, requisicaoSemNome, token);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("NOME_USUARIO_EMBRANCO");
        erros.Should().ContainSingle().And.Contain(c => c.GetString().Equals(mensagemEsperada));
    }
}
