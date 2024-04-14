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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status201Created)]
    [ServiceFilter(typeof(AdminAutenticadoAttribute))]
    public async Task<IActionResult> AnalisarPedidoFerias(
        [FromServices] IAnalisarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoAnalisarPedidoFeriasJson requisicao,
        [FromRoute] long id)
    {
        var resposta = await useCase.Executar(id, requisicao);

        return Created(string.Empty, resposta);
    }
}
