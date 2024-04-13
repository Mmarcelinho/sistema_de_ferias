using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;

namespace SistemaDeFerias.Application.UseCases.PedidoFerias;

public class PedidoFeriasValidator : AbstractValidator<RequisicaoSolicitarPedidoFeriasJson>
{
    public PedidoFeriasValidator()
    {
        RuleFor(x => x.DataInicio).NotEmpty().WithMessage(ResourceMensagensDeErro.DATA_INICIO_DO_PEDIDOFERIAS_EMBRANCO);
        RuleFor(x => x.Dias).NotEmpty().WithMessage(ResourceMensagensDeErro.QTD_DIAS_DO_PEDIDOFERIAS);
    }
}
