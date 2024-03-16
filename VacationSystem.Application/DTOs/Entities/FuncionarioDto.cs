namespace VacationSystem.Application.DTOs.Entities;

    public record InsercaoFuncionarioRequest
    (
        string Nome, 
        string Funcao, 
        string Setor, 
        DateTime DataInicio, 
        int DepartamentoId
    );

    public record AtualizacaoFuncionarioRequest
    (
        string Nome, 
        string Funcao, 
        string Setor, 
        DateTime DataInicio, 
        int DepartamentoId
    );

    public record FuncionarioResponse
    (
        string Nome, 
        string Funcao, 
        string Setor, 
        DateTime DataInicio, 
        int DepartamentoId,
        string DepartamentoNome
    );


