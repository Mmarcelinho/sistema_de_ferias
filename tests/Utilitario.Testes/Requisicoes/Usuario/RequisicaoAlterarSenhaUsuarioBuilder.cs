namespace Utilitario.Testes.Requisicoes.Usuario;

public class RequisicaoAlterarSenhaUsuarioBuilder
{
    public static RequisicaoAlterarSenhaJson Construir(int tamanhoSenha = 10)
    {
        return new Faker<RequisicaoAlterarSenhaJson>()
            .RuleFor(c => c.SenhaAtual, f => f.Internet.Password(10))
            .RuleFor(c => c.NovaSenha, f => f.Internet.Password(tamanhoSenha));
    }
}