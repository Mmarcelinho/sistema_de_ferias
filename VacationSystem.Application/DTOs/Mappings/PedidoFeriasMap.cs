using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

public static class PedidoFeriasMap
{
    public static PedidoFeriasResponse ConverterParaResponse(this PedidoFerias pedido) => new
    (
        pedido.Id,
        pedido.DataPedido.Date,
        pedido.Dias,
        pedido.DataInicio,
        pedido.DataFim,
        pedido.Status,
        pedido.FuncionarioId,
        pedido.Funcionario.Nome,
        pedido.Funcionario.Funcao,
        pedido.Funcionario.Setor,
        pedido.Funcionario.DataInicio.Date,
        pedido.Funcionario.DataFimUltimaFerias,
        pedido.Funcionario.DepartamentoId,
        pedido.Funcionario.Departamento.Nome
    );

    public static AprovarPedidoFeriasResponse ConverterParaResponseAprovacao(this PedidoFerias pedido) => new
    (
        pedido.Id,
        pedido.DataPedido.Date,
        pedido.Dias,
        pedido.DataInicio,
        pedido.DataFim,
        pedido.Status,
        pedido.FuncionarioId,
        pedido.Funcionario.Nome,
        pedido.Funcionario.Funcao,
        pedido.Funcionario.Setor,
        pedido.Funcionario.DataInicio.Date,
        pedido.Funcionario.DataFimUltimaFerias,
        pedido.Funcionario.DepartamentoId,
        pedido.Funcionario.Departamento.Nome,
        pedido.AdminId,
        pedido.Admin.Nome,
        pedido.Admin.Cargo,
        pedido.Admin.LevelAcesso
    );
}
