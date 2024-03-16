using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

public static class AdminMap
{
    public static Admin ConverterParaEntidade(InsercaoAdminRequest insercaoAdmin) => new
    (
        insercaoAdmin.Nome,
        insercaoAdmin.Cargo,
        insercaoAdmin.LevelAcesso
    );

    public static Admin ConverterParaEntidade(AtualizacaoAdminRequest atualizacaoAdmin) => new
    (
        atualizacaoAdmin.Nome,
        atualizacaoAdmin.Cargo,
        atualizacaoAdmin.LevelAcesso
    );

    public static AdminResponse ConverterParaResponse(this Admin admin) => new
    (
        admin.Id,
        admin.Nome,
        admin.Cargo,
        admin.LevelAcesso
    );
}
