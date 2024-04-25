namespace WebApi.Test.V1.Usuario.Funcionario.AlterarSenha;

public class AlterarSenhaFuncionarioTest : ControllerBase
{
    private const string METODO = "funcionario/alterar-senha";

    private const string METODOLOGIN = "funcionario";

    private SistemaDeFerias.Domain.Entidades.Funcionario _funcionario;

    private string _senha;
    
    public AlterarSenhaFuncionarioTest(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _funcionario = factory.RecuperarFuncionarioSemPedido();
        _senha = factory.RecuperarSenhaFuncionarioSemPedido();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token = await Login(METODOLOGIN, _funcionario.Email, _senha);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaAtual = requisicao with { SenhaAtual = _senha };

        var resposta = await PutRequest(METODO, requisicaoSenhaAtual, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Validar_Erro_SenhaEmBranco()
    {
        var token = await Login(METODOLOGIN, _funcionario.Email, _senha);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaEmBranco = requisicao with { SenhaAtual = _senha, NovaSenha = string.Empty };

        var resposta = await PutRequest(METODO, requisicaoSenhaEmBranco, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var respostaBody = await resposta.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(respostaBody);

        var erros = responseData.RootElement.GetProperty("mensagens").EnumerateArray();

        var mensagemEsperada = ResourceMensagensDeErro.ResourceManager.GetString("SENHA_USUARIO_EMBRANCO");

        erros.Should().ContainSingle().And.Contain(c => c.GetString().Equals(mensagemEsperada));
    }

}