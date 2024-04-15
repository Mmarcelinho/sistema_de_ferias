namespace SistemaDeFerias.Application.UseCases.Setor.Atualizar;

    public class AtualizarSetorValidator : AbstractValidator<RequisicaoSetorJson>
    {
        public AtualizarSetorValidator() =>
        RuleFor(x => x).SetValidator(new SetorValidator());
    }
