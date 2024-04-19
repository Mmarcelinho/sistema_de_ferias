namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;

public class RegistrarAdminValidator : AbstractValidator<RequisicaoRegistrarAdminJson>
{
    public RegistrarAdminValidator()
    {
        RuleFor(x => x).SetValidator(new RegistrarUsuarioValidator());
        RuleFor(c => c.Cargo).NotEmpty().WithMessage(ResourceMensagensDeErro.CARGO_ADMIN_EMBRANCO);
        RuleFor(c => c.DepartamentoId).NotEmpty().WithMessage(ResourceMensagensDeErro.DEPARTAMENTO_INVALIDO);
    }
}