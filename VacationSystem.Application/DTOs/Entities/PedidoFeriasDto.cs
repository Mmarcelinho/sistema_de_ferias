using System.Data;

namespace VacationSystem.Application.DTOs.Entities;

public record PedidoFeriasRequest
    (
        DateTime DataInicio,
        int Dias
    );

    public record PedidoFeriasResponse
    (
        string FuncionarioNome,
        string FuncionarioFuncao,
        string FuncionarioSetor,
        int FuncionarioId,
        DateTime DataInicio,
        DateTime? DataFimUltimasFerias,
        string DepartamentoNome,
        int DepartamentoId,
        DateTime DataPedido,
        DateTime DataInicioPedido,
        DateTime DataFim,
        int PedidoFeriasId,
        int Dias,
        string Status
    );