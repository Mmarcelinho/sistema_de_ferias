using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;

    public class RegistrarPedidoFeriasValidator : AbstractValidator<RequisicaoSolicitarPedidoFeriasJson>
{
    public RegistrarPedidoFeriasValidator()
    {
        RuleFor(x => x).SetValidator(new PedidoFeriasValidator());
    }
}

