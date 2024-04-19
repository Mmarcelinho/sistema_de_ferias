namespace SistemaDeFerias.Api.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Admin>))]
public class SetorController : SistemaDeFeriasController
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(RespostaSetorListJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarTodos(
    [FromServices] IRecuperarTodosSetoresUseCase useCase)
    {
        var resposta = await useCase.Executar();
        if (resposta.Setores.Count == 0)
            return Ok(resposta);

        return NoContent();
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(RespostaSetorJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPorId(
    [FromServices] IRecuperarSetorPorIdUseCase useCase,
    [FromRoute] long id)
    {
        var resposta = await useCase.Executar(id);

        return Ok(resposta);
    }

    [HttpGet]
    [Route("{nome:alpha}")]
    [ProducesResponseType(typeof(RespostaSetorJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPorNome(
    [FromServices] IRecuperarSetorPorNomeUseCase useCase,
    [FromRoute] string nome)
    {
        var resposta = await useCase.Executar(nome);

        return Ok(resposta);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RespostaSetorJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarSetorUseCase useCase,
        [FromBody] RequisicaoSetorJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Atualizar(
    [FromServices] IAtualizarSetorUseCase useCase,
    [FromBody] RequisicaoSetorJson requisicao,
    [FromRoute] long id)
    {
        await useCase.Executar(id, requisicao);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deletar(
    [FromServices] IDeletarSetorUseCase useCase,
    [FromRoute] long id)
    {
        await useCase.Executar(id);

        return NoContent();
    }
}
