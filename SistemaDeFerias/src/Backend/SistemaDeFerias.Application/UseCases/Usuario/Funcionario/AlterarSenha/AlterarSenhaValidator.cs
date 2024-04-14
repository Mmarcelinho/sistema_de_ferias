namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.AlterarSenha;

    public class AlterarSenhaValidator : AbstractValidator<RequisicaoAlterarSenhaJson>
    {
        public AlterarSenhaValidator()
        {
            RuleFor(c => c.NovaSenha).SetValidator(new SenhaValidator());
        }
    }

