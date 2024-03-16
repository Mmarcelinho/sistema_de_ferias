using Carter;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Application.DTOs.Mappings;

namespace VacationSystem.Api.Endpoints.v1;

public class PedidoFeriasEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("v1/pedidos");

        group.MapGet("", ObterPedidoFerias)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status200OK)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPedidoFerias));

        group.MapGet("{id:int}", ObterPedidoFeriasPorId)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status200OK)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPedidoFeriasPorId));
    }

    public static async Task<IResult> ObterPedidoFerias(
    IUnitOfWork _unitOfWork)
    {
        var pedidos = await _unitOfWork.PedidoFeriasRepository.ObterTodosAsync();

        var pedidosResponse = pedidos.Select(pedidos => pedidos.ConverterParaResponse());

        return Results.Ok(pedidosResponse);
    }

    public static async Task<IResult> ObterPedidoFeriasPorId(
    int id,
    IUnitOfWork _unitOfWork)
    {
        var pedido = await _unitOfWork.PedidoFeriasRepository.ObterPorIdAsync(id);

        if (pedido is null)
            return Results.NotFound();

        var pedidoResponse = PedidoFeriasMap.ConverterParaResponse(pedido);

        return Results.Ok(pedidoResponse);
    }
}