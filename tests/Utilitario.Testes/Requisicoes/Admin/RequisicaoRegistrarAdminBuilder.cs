namespace Utilitario.Testes.Requisicoes.Admin;

    public class RequisicaoRegistrarAdminBuilder
    {
        public static RequisicaoRegistrarAdminJson Construir(int tamanhoSenha = 10)
    {
        return new Faker<RequisicaoRegistrarAdminJson>()
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f => f.Internet.Password(tamanhoSenha))
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
            .RuleFor(c => c.Cargo, f => f.Name.JobTitle())
            .RuleFor(c => c.DepartamentoId, f => f.Random.Int());
    }
    }
