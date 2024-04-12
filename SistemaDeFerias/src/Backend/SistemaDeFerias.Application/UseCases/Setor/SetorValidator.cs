namespace SistemaDeFerias.Application.UseCases.Setor;

    public class SetorValidator : AbstractValidator<RequisicaoSetorJson>
    {
        public SetorValidator() =>
            RuleFor(x => x.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_DO_SETOR_EMBRANCO);
    }
