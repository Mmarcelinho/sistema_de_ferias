namespace Utilitario.Testes.Requisicoes.Funcionario;

public class RequisicaoRegistrarFuncionarioBuilder
{
    public static RequisicaoRegistrarFuncionarioJson Construir(int tamanhoSenha = 10)
    {
        return new Faker<RequisicaoRegistrarFuncionarioJson>()
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f => f.Internet.Password(tamanhoSenha))
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
            .RuleFor(c => c.DataEntrada, f => f.Date.Between(DateTime.Now.AddYears(-2),DateTime.Now))
            .RuleFor(c => c.Funcao, f => f.Name.JobTitle())
            .RuleFor(c => c.DepartamentoId, f => f.Random.Int(1, 100));
    }

}
