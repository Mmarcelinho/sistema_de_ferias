using System.Data;

namespace VacationSystem.Application.DTOs.Entities;

public record PedidoFeriasRequest
    (
        DateTime DataInicio,
        int Dias
    );

public record PedidoFeriasResponse
(
    int PedidoFeriasId,
    DateTime DataPedido,
    int Dias,
    DateTime DataInicioPedido,
    DateTime DataFim,
    string Status,
    int FuncionarioId,
    string FuncionarioNome,
    string FuncionarioFuncao,
    string FuncionarioSetor,
    DateTime DataInicio,
    DateTime? DataFimUltimasFerias,
    int DepartamentoId,
    string DepartamentoNome
);

public record AprovarPedidoFeriasRequest
   (
       bool Aprovacao
   );

public record AprovarPedidoFeriasResponse
(
    int PedidoFeriasId,
    DateTime DataPedido,
    int Dias,
    DateTime DataInicioPedido,
    DateTime DataFim,
    string Status,
    int FuncionarioId,
    string FuncionarioNome,
    string FuncionarioFuncao,
    string FuncionarioSetor,
    DateTime DataInicio,
    DateTime? DataFimUltimasFerias,
    int DepartamentoId,
    string DepartamentoNome,
    int? AdminId,
    string AdminNome,
    string AdminCargo,
    string AdminLevelAcesso
);