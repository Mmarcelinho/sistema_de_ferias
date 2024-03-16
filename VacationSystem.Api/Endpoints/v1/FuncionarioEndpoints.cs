using Carter;
using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Application.DTOs.Mappings;

namespace VacationSystem.Api.Endpoints.v1;

public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("v1/funcionarios");

        group.MapGet("", ObterFuncionarios)
        .Produces<FuncionarioResponse>(StatusCodes.Status200OK)
        .Produces<FuncionarioResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFuncionarios));

        group.MapGet("{id:int}", ObterFuncionarioPorId)
        .Produces<FuncionarioResponse>(StatusCodes.Status200OK)
        .Produces<FuncionarioResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFuncionarioPorId));

        group.MapPost("", InserirFuncionario)
        .Produces<FuncionarioResponse>(StatusCodes.Status201Created)
        .Produces<FuncionarioResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirFuncionario));

        group.MapPut("", AtualizarFuncionario)
        .Produces<FuncionarioResponse>(StatusCodes.Status204NoContent)
        .Produces<FuncionarioResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarFuncionario));

        group.MapDelete("{id:int}", RemoverFuncionario)
        .Produces<FuncionarioResponse>(StatusCodes.Status204NoContent)
        .Produces<FuncionarioResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverFuncionario));
    }

    public static async Task<IResult> ObterFuncionarios(
    IUnitOfWork _unitOfWork)
    {
        var funcionarios = await _unitOfWork.FuncionarioRepository.ObterTodosAsync();

        var funcionariosReponse = funcionarios.Select(funcionario => funcionario.ConverterParaResponse());

        return Results.Ok(funcionariosReponse);
    }

    public static async Task<IResult> ObterFuncionarioPorId(
    int id,
    IUnitOfWork _unitOfWork)
    {
        var funcionario = await _unitOfWork.FuncionarioRepository.ObterPorIdAsync(id);

        if (funcionario is null)
            return Results.NotFound();

        var funcionarioResponse = FuncionarioMap.ConverterParaResponse(funcionario);

        return Results.Ok(funcionarioResponse);
    }

    public static async Task<IResult> InserirFuncionario(
    IUnitOfWork _unitOfWork, InsercaoFuncionarioRequest insercaoFuncionario)
    {
        var funcionario = FuncionarioMap.ConverterParaEntidade(insercaoFuncionario);
        var id = (int)await _unitOfWork.FuncionarioRepository.AdicionarAsync(funcionario);

        return Results.CreatedAtRoute(nameof(ObterFuncionarioPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarFuncionario(
    IUnitOfWork _unitOfWork, AtualizacaoFuncionarioRequest atualizacaoFuncionario, int id)
    {
        var funcionario = FuncionarioMap.ConverterParaEntidade(atualizacaoFuncionario);

        var existingFuncionario = await _unitOfWork.FuncionarioRepository.ObterPorIdAsync(id);

        existingFuncionario.Atualizar(funcionario.Nome, funcionario.Funcao, funcionario.Setor, funcionario.DepartamentoId);

        _unitOfWork.FuncionarioRepository.AtualizarAsync(existingFuncionario);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverFuncionario(
    IUnitOfWork _unitOfWork, int id)
    {
        _unitOfWork.FuncionarioRepository.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}