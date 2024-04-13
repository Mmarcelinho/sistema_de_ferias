namespace SistemaDeFerias.Application.UseCases.Departamento.Atualizar;

    public class AtualizarDepartamentoValidator : AbstractValidator<RequisicaoDepartamentoJson>
    {
        public AtualizarDepartamentoValidator() =>
        RuleFor(x => x).SetValidator(new DepartamentoValidator());
    }
