using VacationSystem.Application.DTOs.Entities;
using VacationSystem.Domain.Entities;

namespace VacationSystem.Application.DTOs.Mappings;

public static class PedidoFeriasMap
{
    public static PedidoFeriasResponse ConverterParaResponse(this PedidoFerias pedido) => new
    (
        pedido.Funcionario.Nome,
        pedido.Funcionario.Funcao,
        pedido.Funcionario.Setor,
        pedido.FuncionarioId,
        pedido.Funcionario.DataInicio.Date,
        pedido.Funcionario.DataFimUltimaFerias,
        pedido.Funcionario.Departamento.Nome,
        pedido.Funcionario.DepartamentoId,
        pedido.DataPedido.Date,
        pedido.DataInicio,
        pedido.DataFim,
        pedido.Id,
        pedido.Dias,
        pedido.Status
    );
}
