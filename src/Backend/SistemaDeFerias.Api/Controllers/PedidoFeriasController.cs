namespace SistemaDeFerias.Api.Controllers;

public class PedidoFeriasController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status201Created)]
    [ServiceFilter(typeof(FuncionarioAutenticadoAttribute))]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoSolicitarPedidoFeriasJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpPut]
    [Route("atualizar/{id:int}")]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(FuncionarioAutenticadoAttribute))]
    public async Task<IActionResult> AtualizarPedidoFerias(
        [FromServices] IAtualizarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoSolicitarPedidoFeriasJson requisicao,
        [FromRoute] long id)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }

    [HttpPut]
    [Route("analisar/{id:int}")]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(AdminAutenticadoAttribute))]
    public async Task<IActionResult> AnalisarPedidoFerias(
        [FromServices] IAnalisarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoAnalisarPedidoFeriasJson requisicao,
        [FromRoute] long id)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }
}
