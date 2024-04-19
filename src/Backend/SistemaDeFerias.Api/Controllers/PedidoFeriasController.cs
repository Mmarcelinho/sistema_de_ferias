namespace SistemaDeFerias.Api.Controllers;

public class PedidoFeriasController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status201Created)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoSolicitarPedidoFeriasJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RespostaPedidoFeriasJson), StatusCodes.Status200OK)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> RecuperarPorId(
    [FromServices] IRecuperarPedidoFeriasPorIdUseCase useCase,
    [FromRoute] long id)
    {
        var resposta = await useCase.Executar(id);

        return Ok(resposta);
    }

    [HttpPut]
    [Route("atualizar/{id:int}")]
    [ProducesResponseType(typeof(RespostaPedidoFeriasSolicitacaoJson), StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
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
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Admin>))]
    public async Task<IActionResult> AnalisarPedidoFerias(
        [FromServices] IAnalisarPedidoFeriasUseCase useCase,
        [FromBody] RequisicaoAnalisarPedidoFeriasJson requisicao,
        [FromRoute] long id)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> DeletarPedidoFerias(
        [FromServices] IDeletarPedidoFeriasUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Executar(id);

        return NoContent();
    }
}
