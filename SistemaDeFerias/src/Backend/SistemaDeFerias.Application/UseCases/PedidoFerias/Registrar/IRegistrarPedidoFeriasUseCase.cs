using SistemaDeFerias.Comunicacao.Requisicoes.PedidoFerias;
using SistemaDeFerias.Comunicacao.Respostas.PedidoFerias;

namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;

    public interface IRegistrarPedidoFeriasUseCase
    {
        Task<RespostaPedidoFeriasSolicitacaoJson> Executar(RequisicaoSolicitarPedidoFeriasJson requisicao);
    }
