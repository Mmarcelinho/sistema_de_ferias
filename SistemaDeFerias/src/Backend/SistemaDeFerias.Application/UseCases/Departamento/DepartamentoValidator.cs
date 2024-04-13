namespace SistemaDeFerias.Application.UseCases.Departamento;

    public class DepartamentoValidator : AbstractValidator<RequisicaoDepartamentoJson>
    {
        public DepartamentoValidator() 
        {
             RuleFor(x => x.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_DO_DEPARTAMENTO_EMBRANCO);
            RuleFor(x => x.SetorId).NotEmpty().WithMessage(ResourceMensagensDeErro.SETOR_INVALIDO);
        }

    }
