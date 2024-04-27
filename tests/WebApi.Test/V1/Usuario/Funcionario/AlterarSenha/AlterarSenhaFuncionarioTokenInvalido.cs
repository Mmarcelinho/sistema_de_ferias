namespace WebApi.Test.V1.Usuario.Funcionario.AlterarSenha;

public class AlterarSenhaFuncionarioTokenInvalido : ControllerBase
{
    private const string METODO = "funcionario/alterar-senha";

    private SistemaDeFerias.Domain.Entidades.Funcionario _funcionario;

    private string _senha;
    
    public AlterarSenhaFuncionarioTokenInvalido(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _funcionario = factory.RecuperarFuncionarioSemPedido();
        _senha = factory.RecuperarSenhaFuncionarioSemPedido();
    }

    [Fact]
    public async Task Validar_Erro_Token_Vazio()
    {
        var token = string.Empty;

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaAtual = requisicao with { SenhaAtual = _senha };

        var resposta = await PutRequest(METODO, requisicaoSenhaAtual, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Validar_Erro_Token_Usuario_Fake()
    {
        var token = TokenControllerBuilder.Instancia().GerarToken("usuario@fake.com");

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaAtual = requisicao with { SenhaAtual = _senha };

        var resposta = await PutRequest(METODO, requisicaoSenhaAtual, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Validar_Erro_Token_Expirado()
    {
        var token = TokenControllerBuilder.TokenExpirado().GerarToken(_funcionario.Email);
        
        await Task.Delay(1000);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaAtual = requisicao with { SenhaAtual = _senha };

        var resposta = await PutRequest(METODO, requisicaoSenhaAtual, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}