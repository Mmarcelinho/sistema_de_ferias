namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;

public class RegistrarAdminValidator : AbstractValidator<RequisicaoRegistrarAdminJson>
{
    public RegistrarAdminValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO);
        RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagensDeErro.TELEFONE_USUARIO_EMBRANCO);
        RuleFor(c => c.Senha).SetValidator(new SenhaValidator());
        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO);
        });
        When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
        {
            RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
            {
                string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                var isMatch = Regex.IsMatch(telefone, padraoTelefone);
                if (!isMatch)
                {
                    contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensDeErro.TELEFONE_USUARIO_INVALIDO));
                }
            });
        });
        RuleFor(c => c.Cargo).NotEmpty().WithMessage(ResourceMensagensDeErro.CARGO_ADMIN_EMBRANCO);
        RuleFor(c => c.DepartamentoId).NotEmpty().WithMessage(ResourceMensagensDeErro.DEPARTAMENTO_INVALIDO);
    }
}