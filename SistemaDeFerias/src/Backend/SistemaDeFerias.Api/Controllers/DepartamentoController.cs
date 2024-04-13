namespace SistemaDeFerias.Api.Controllers;

public class DepartamentoController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaDepartamentoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarDepartamentoUseCase useCase,
        [FromBody] RequisicaoDepartamentoJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RespostaDepartamentoJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPorId(
    [FromServices] IRecuperarDepartamentoPorIdUseCase useCase,
    [FromRoute] long id)
    {
        var resposta = await useCase.Executar(id);

        return Ok(resposta);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Atualizar(
    [FromServices] IAtualizarDepartamentoUseCase useCase,
    [FromBody] RequisicaoDepartamentoJson requisicao,
    [FromRoute] long id)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deletar(
    [FromServices] IDeletarDepartamentoUseCase useCase,
    [FromRoute] long id)
    {
        await useCase.Executar(id);

        return NoContent();
    }
}
