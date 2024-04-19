namespace SistemaDeFerias.Api.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
public class DepartamentoController : SistemaDeFeriasController
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(RespostaDepartamentoListJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarTodos(
    [FromServices] IRecuperarTodosDepartamentosUseCase useCase)
    {
        var resposta = await useCase.Executar();
        if (resposta.Departamentos.Count == 0)
            return Ok(resposta);

        return NoContent();
    }

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

    [HttpGet]
    [Route("{nome:alpha}")]
    [ProducesResponseType(typeof(RespostaDepartamentoJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPorNome(
    [FromServices] IRecuperarDepartamentoPorNomeUseCase useCase,
    [FromRoute] string nome)
    {
        var resposta = await useCase.Executar(nome);

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
