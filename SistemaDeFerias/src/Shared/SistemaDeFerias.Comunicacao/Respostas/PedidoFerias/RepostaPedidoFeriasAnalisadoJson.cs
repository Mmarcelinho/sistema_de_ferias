using SistemaDeFerias.Comunicacao.Enum;

namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

    public record RepostaPedidoFeriasAnalisadoJson(long FuncionarioId, long AdminId, DateTime DataPedido, DateTime DataInicio, DateTime DataFim, int Dias, Status Status);