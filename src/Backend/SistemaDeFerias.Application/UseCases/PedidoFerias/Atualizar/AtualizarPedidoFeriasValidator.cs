namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Atualizar;

    public class  AtualizarPedidoFeriasValidator : AbstractValidator<RequisicaoSolicitarPedidoFeriasJson>
    {
        public AtualizarPedidoFeriasValidator() =>
        RuleFor(x => x).SetValidator(new PedidoFeriasValidator());
    }