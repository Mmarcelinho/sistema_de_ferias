namespace WebApi.Test.V1.Usuario.Admin.AlterarSenha;

public class AlterarSenhaAdminTokenInvalido : ControllerBase
{
    private const string METODO = "admin/alterar-senha";

    private readonly SistemaDeFerias.Domain.Entidades.Admin _admin;

    private readonly string _senha;
    
    public AlterarSenhaAdminTokenInvalido(SistemaDeFeriasWebApplicationFactory<Program> factory) : base(factory)
    { 
        _admin = factory.RecuperarAdminSemPedido();
        _senha = factory.RecuperarSenhaAdminSemPedido();
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
        var token = TokenControllerBuilder.TokenExpirado().GerarToken(_admin.Email);
        
        await Task.Delay(1000);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var requisicaoSenhaAtual = requisicao with { SenhaAtual = _senha };

        var resposta = await PutRequest(METODO, requisicaoSenhaAtual, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}