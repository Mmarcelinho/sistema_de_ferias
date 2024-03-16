using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

public static class FuncionarioMap
{
    public static Funcionario ConverterParaEntidade(InsercaoFuncionarioRequest insercaoFuncionario) => new
    (
        insercaoFuncionario.Nome,
        insercaoFuncionario.Funcao,
        insercaoFuncionario.Setor,
        insercaoFuncionario.DataInicio,
        insercaoFuncionario.DepartamentoId
    );

    public static Funcionario ConverterParaEntidade(AtualizacaoFuncionarioRequest atualizacaoFuncionario) => new
    (
        atualizacaoFuncionario.Nome,
        atualizacaoFuncionario.Funcao, 
        atualizacaoFuncionario.Setor, 
        atualizacaoFuncionario.DataInicio, 
        atualizacaoFuncionario.DepartamentoId
    );

    public static FuncionarioResponse ConverterParaResponse(this Funcionario funcionario) => new
    (
        funcionario.Id, 
        funcionario.Nome, 
        funcionario.Funcao, 
        funcionario.Setor, 
        funcionario.DataInicio.Date, 
        funcionario.DepartamentoId, 
        funcionario.Departamento.Nome
    );
}
