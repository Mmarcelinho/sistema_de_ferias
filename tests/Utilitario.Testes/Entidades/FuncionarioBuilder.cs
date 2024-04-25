namespace Utilitario.Testes.Entidades;

public class FuncionarioBuilder
{
    public static (Funcionario funcionario, string senha) Construir(long id = 1)
    {
        (var funcionario, var senha) = CriarFuncionario(id);
        return (funcionario, senha);
    }

    private static (Funcionario funcionario, string senha) CriarFuncionario(long id)
    {
        string senha = string.Empty;

        var funcionarioGerado = new Faker<Funcionario>()
        .RuleFor(c => c.Id, _ => id)
        .RuleFor(c => c.Nome, f => f.Person.FullName)
        .RuleFor(c => c.Email, f => f.Internet.Email())
        .RuleFor(c => c.Senha, f =>
        {
            senha = f.Internet.Password();

            return EncriptadorDeSenhaBuilder.Instancia().Criptografar(senha);
        })
        .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
        .RuleFor(c => c.DataEntrada, f => f.Date.Between(DateTime.Now.AddYears(-2),DateTime.Now))
        .RuleFor(c => c.Funcao, f => f.Name.JobType())
        .RuleFor(c => c.DepartamentoId, _ => id);

        return (funcionarioGerado, senha);
    }
}
