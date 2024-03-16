namespace VacationSystem.Application.DTOs.Entities;

    public record InsercaoAdminRequest
    (
        string Nome,
        string Cargo,
        string LevelAcesso
    );

    public record AtualizacaoAdminRequest
    (
        string Nome,
        string Cargo,
        string LevelAcesso
    );

    public record AdminResponse
    (
        int Id,
        string Nome,
        string Cargo,
        string LevelAcesso
    );


