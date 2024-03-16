using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

    public static class FuncionarioMap
    {
        public static Funcionario ConverterParaEntidade(InsercaoFuncionarioRequest insercaoFuncionario) => new Funcionario(insercaoFuncionario.Nome,insercaoFuncionario.Funcao,insercaoFuncionario.Setor,insercaoFuncionario.DataInicio,insercaoFuncionario.DepartamentoId);

        public static Funcionario ConverterParaEntidade(AtualizacaoFuncionarioRequest atualizacaoFuncionario) => new Funcionario(atualizacaoFuncionario.Nome,atualizacaoFuncionario.Funcao,atualizacaoFuncionario.Setor,atualizacaoFuncionario.DataInicio,atualizacaoFuncionario.DepartamentoId);

        public static FuncionarioResponse ConverterParaResponse(this Funcionario funcionario) => new FuncionarioResponse(funcionario.Nome,funcionario.Funcao,funcionario.Setor,funcionario.DataInicio,funcionario.DepartamentoId,funcionario.Departamento.Nome);
    }
