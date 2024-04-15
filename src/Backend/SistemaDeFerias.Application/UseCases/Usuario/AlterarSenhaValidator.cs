namespace SistemaDeFerias.Application.UseCases.Usuario;

    public class AlterarSenhaValidator : AbstractValidator<RequisicaoAlterarSenhaJson>
    {
        public AlterarSenhaValidator()
        {
            RuleFor(c => c.NovaSenha).SetValidator(new SenhaValidator());
        }
    }

