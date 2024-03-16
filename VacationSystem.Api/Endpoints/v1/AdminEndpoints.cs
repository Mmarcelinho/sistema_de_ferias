using Carter;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Application.DTOs.Mappings;
using VacationSystem.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace VacationSystem.Api.Endpoints.v1;

public class AdminEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("v1/admin");

        group.MapPut("/aprovar-pedido-ferias/admin/{adminId:int}/pedido/{pedidoFeriasId:int}", AprovarPedidoFerias)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status200OK)
        .Produces<PedidoFeriasResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(AprovarPedidoFerias));

        group.MapGet("", ObterAdmins)
        .Produces<AdminResponse>(StatusCodes.Status200OK)
        .Produces<AdminResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterAdmins));

        group.MapGet("{id:int}", ObterAdminPorId)
        .Produces<AdminResponse>(StatusCodes.Status200OK)
        .Produces<AdminResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterAdminPorId));

        group.MapPost("", InserirAdmin)
        .Produces<AdminResponse>(StatusCodes.Status201Created)
        .Produces<AdminResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirAdmin));

        group.MapPut("", AtualizarAdmin)
        .Produces<AdminResponse>(StatusCodes.Status204NoContent)
        .Produces<AdminResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarAdmin));

        group.MapDelete("{id:int}", RemoverAdmin)
        .Produces<AdminResponse>(StatusCodes.Status204NoContent)
        .Produces<AdminResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverAdmin));
    }

    public static async Task<IResult> AprovarPedidoFerias(
    IUnitOfWork _unitOfWork,
    IPedidoFeriasService pedidoFeriasService,
    [FromBody] bool aprovacao,
    [FromRoute] int adminId,
    [FromRoute] int pedidoFeriasId)
    {
        var pedidoFerias = await _unitOfWork.PedidoFeriasRepository.ObterPorIdAsync(pedidoFeriasId);

        if (pedidoFerias is null)
            return Results.NotFound("Pedido não encontrado.");

        var admin = await _unitOfWork.AdminRepository.ObterPorIdAsync(adminId);

        if (admin is null)
            return Results.NotFound("Administrador não encontrado.");

        var pedido = pedidoFeriasService.AprovarPedidoFerias(pedidoFerias, admin, aprovacao);
        await _unitOfWork.CommitAsync();
        //var pedidoResponse = pedido.ConverterParaResponseAprovacao();

        return Results.Ok(pedido);
    }

    public static async Task<IResult> ObterAdmins(
    IUnitOfWork _unitOfWork)
    {
        var admins = await _unitOfWork.AdminRepository.ObterTodosAsync();

        var adminsReponse = admins.Select(admin => admin.ConverterParaResponse());

        return Results.Ok(adminsReponse);
    }

    public static async Task<IResult> ObterAdminPorId(
    int id,
    IUnitOfWork _unitOfWork)
    {
        var admin = await _unitOfWork.AdminRepository.ObterPorIdAsync(id);

        if (admin is null)
            return Results.NotFound();

        var adminResponse = AdminMap.ConverterParaResponse(admin);

        return Results.Ok(adminResponse);
    }

    public static async Task<IResult> InserirAdmin(
    IUnitOfWork _unitOfWork, InsercaoAdminRequest insercaoAdmin)
    {
        var admin = AdminMap.ConverterParaEntidade(insercaoAdmin);
        var id = (int)await _unitOfWork.AdminRepository.AdicionarAsync(admin);
        await _unitOfWork.CommitAsync();

        return Results.CreatedAtRoute(nameof(ObterAdminPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarAdmin(
    IUnitOfWork _unitOfWork, AtualizacaoAdminRequest atualizacaoAdmin, int id)
    {
        var admin = AdminMap.ConverterParaEntidade(atualizacaoAdmin);

        var existingAdmin = await _unitOfWork.AdminRepository.ObterPorIdAsync(id);

        existingAdmin.Atualizar(admin.Nome, admin.Cargo, admin.LevelAcesso);

        _unitOfWork.AdminRepository.AtualizarAsync(existingAdmin);
        await _unitOfWork.CommitAsync();

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverAdmin(
    IUnitOfWork _unitOfWork, int id)
    {
        await _unitOfWork.AdminRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        return Results.NoContent();
    }
}