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
    string Status
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
    int AdminId
);