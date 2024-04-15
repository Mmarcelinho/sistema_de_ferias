namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;

    public class  AnalisarPedidoFeriasValidator : AbstractValidator<RequisicaoAnalisarPedidoFeriasJson>
    {
        public AnalisarPedidoFeriasValidator()
        {
            RuleFor(x => x.Status).IsInEnum().WithMessage(ResourceMensagensDeErro.STATUS_DA_SOLICITACAO_INVALIDO);
        }
    }