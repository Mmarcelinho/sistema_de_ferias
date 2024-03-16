using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

    public static class DepartamentoMap
    {
        public static Departamento ConverterParaEntidade(InsercaoDepartamentoRequest insercaoDepartamento) => new(insercaoDepartamento.Nome);

        public static Departamento ConverterParaEntidade(AtualizacaoDepartamentoRequest atualizacaoDepartamento) => new (atualizacaoDepartamento.Nome);

        public static DepartamentoResponse ConverterParaResponse(this Departamento departamento) => new(departamento.Id,departamento.Nome);
    }
