namespace SistemaDeFerias.Application.UseCases.Departamento.Registrar;

    public class RegistrarDepartamentoValidator : AbstractValidator<RequisicaoDepartamentoJson>
    {
        public RegistrarDepartamentoValidator() =>
        RuleFor(x => x).SetValidator(new DepartamentoValidator());
    }
