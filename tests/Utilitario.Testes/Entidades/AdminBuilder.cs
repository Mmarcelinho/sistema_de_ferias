namespace Utilitario.Testes.Entidades;

    public class AdminBuilder
    {
        public static (Admin admin, string senha) Construir()
        {
           (var admin, var senha) = CriarAdmin();
           admin.Id = 1;
           admin.DepartamentoId = 1;
           return (admin, senha);
        }

        private static(Admin admin, string senha) CriarAdmin()
        {
            string senha = string.Empty;

            var adminGerado = new Faker<Admin>()
            .RuleFor(c => c.Nome, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f =>
            {
                senha = f.Internet.Password();

                return EncriptadorDeSenhaBuilder.Instancia().Criptografar(senha);
            })
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"))
            .RuleFor(c => c.Cargo, f => f.Name.JobTitle());

            return (adminGerado, senha);
        }
    }
