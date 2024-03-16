namespace VacationSystem.Application.DTOs.Entities;

    public record InsercaoDepartamentoRequest
    (
        string Nome
    );

    public record AtualizacaoDepartamentoRequest
    (
        string Nome
    );

    public record DepartamentoResponse
    (
        int Id,
        string Nome
    );


