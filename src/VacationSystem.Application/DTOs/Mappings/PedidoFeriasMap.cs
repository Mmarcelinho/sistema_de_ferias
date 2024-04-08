using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

public static class PedidoFeriasMap
{
    public static PedidoFeriasResponse ConverterParaResponse(this PedidoFerias pedido) => new PedidoFeriasResponse
    (
        pedido.Id,
        pedido.DataPedido,
        pedido.Dias,
        pedido.DataInicio,
        pedido.DataFim,
        pedido.Status
    );


    public static AprovarPedidoFeriasResponse ConverterParaResponseAprovacao(this PedidoFerias pedido) => new
    (
        pedido.Id,
        pedido.DataPedido,
        pedido.Dias,
        pedido.DataInicio,
        pedido.DataFim,
        pedido.Status,
        pedido.FuncionarioId,
        pedido.Admin.Id
    );
}
