using Carter;
using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Application.DTOs.Mappings;
using VacationSystem.Domain.Interfaces.Services;

namespace VacationSystem.Api.Endpoints.v1;

public class DepartamentoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("v1/departamentos");

        group.MapGet("", ObterDepartamentos)
        .Produces<DepartamentoResponse>(StatusCodes.Status200OK)
        .Produces<DepartamentoResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterDepartamentos));

        group.MapGet("{id:int}", ObterDepartamentoPorId)
        .Produces<DepartamentoResponse>(StatusCodes.Status200OK)
        .Produces<DepartamentoResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterDepartamentoPorId));

        group.MapPost("", InserirDepartamento)
        .Produces<DepartamentoResponse>(StatusCodes.Status201Created)
        .Produces<DepartamentoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirDepartamento));

        group.MapPut("", AtualizarDepartamento)
        .Produces<DepartamentoResponse>(StatusCodes.Status204NoContent)
        .Produces<DepartamentoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarDepartamento));

        group.MapDelete("{id:int}", RemoverDepartamento)
        .Produces<DepartamentoResponse>(StatusCodes.Status204NoContent)
        .Produces<DepartamentoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverDepartamento));
    }

    public static async Task<IResult> ObterDepartamentos(
    IUnitOfWork _unitOfWork)
    {
        var departamentos = await _unitOfWork.DepartamentoRepository.ObterTodosAsync();

        var departamentosReponse = departamentos.Select(departamento => departamento.ConverterParaResponse());

        return Results.Ok(departamentosReponse);
    }

    public static async Task<IResult> ObterDepartamentoPorId(
    int id,
    IUnitOfWork _unitOfWork)
    {
        var departamento = await _unitOfWork.DepartamentoRepository.ObterPorIdAsync(id);

        if (departamento is null)
            return Results.NotFound();

        var departamentoResponse = DepartamentoMap.ConverterParaResponse(departamento);

        return Results.Ok(departamentoResponse);
    }

    public static async Task<IResult> InserirDepartamento(
    IUnitOfWork _unitOfWork, InsercaoDepartamentoRequest insercaoDepartamento)
    {
        var departamento = DepartamentoMap.ConverterParaEntidade(insercaoDepartamento);
        var id = (int)await _unitOfWork.DepartamentoRepository.AdicionarAsync(departamento);
        await _unitOfWork.CommitAsync();

        return Results.CreatedAtRoute(nameof(ObterDepartamentoPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarDepartamento(
    IUnitOfWork _unitOfWork, AtualizacaoDepartamentoRequest atualizacaoDepartamento, int id)
    {
        var departamento = DepartamentoMap.ConverterParaEntidade(atualizacaoDepartamento);

        var existingDepartamento = await _unitOfWork.DepartamentoRepository.ObterPorIdAsync(id);

        existingDepartamento.Atualizar(departamento.Nome);

        _unitOfWork.DepartamentoRepository.AtualizarAsync(existingDepartamento);
        await _unitOfWork.CommitAsync();

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverDepartamento(
    IUnitOfWork _unitOfWork, int id)
    {
        await _unitOfWork.DepartamentoRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        return Results.NoContent();
    }
}