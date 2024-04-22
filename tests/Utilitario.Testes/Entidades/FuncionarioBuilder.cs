namespace Utilitario.Testes.Entidades;

public class FuncionarioBuilder
{
    public static (Funcionario admin, string senha) Construir()
    {
        long departamentoId = 1;
        (var admin, var senha) = CriarAdmin(departamentoId);
        admin.Id = 1;
        return (admin, senha);
    }

    private static (Funcionario admin, string senha) CriarAdmin(long departamentoId)
    {
        string senha = string.Empty;

        var adminGerado = new Faker<Funcionario>()
        .RuleFor(c => c.Nome, f => f.Person.FullName)
        .RuleFor(c => c.Email, f => f.Internet.Email())
        .RuleFor(c => c.Senha, f =>
        {
            senha = f.Internet.Password();

            return EncriptadorDeSenhaBuilder.Instancia().Criptografar(senha);
        })
        .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
        .RuleFor(c => c.DepartamentoId, _ => departamentoId);

        return (adminGerado, senha);
    }
}
