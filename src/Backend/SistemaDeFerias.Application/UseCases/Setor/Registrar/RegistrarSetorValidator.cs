namespace SistemaDeFerias.Application.UseCases.Setor.Registrar;

    public class RegistrarSetorValidator : AbstractValidator<RequisicaoSetorJson>
    {
        public RegistrarSetorValidator() =>
        RuleFor(x => x).SetValidator(new SetorValidator());
    }
