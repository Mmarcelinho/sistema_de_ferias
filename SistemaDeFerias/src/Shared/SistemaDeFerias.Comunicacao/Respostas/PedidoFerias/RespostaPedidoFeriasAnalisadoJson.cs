using SistemaDeFerias.Comunicacao.Enum;

namespace SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

    public record RespostaPedidoFeriasAnalisadoJson(string Id, string DataPedido, string DataInicio, string DataFim, int Dias, Status Status);