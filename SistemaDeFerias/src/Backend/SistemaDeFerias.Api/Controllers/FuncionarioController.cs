namespace SistemaDeFerias.Api.Controllers;

public class FuncionarioController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaFuncionarioRegistradoJson), StatusCodes.Status201Created)]

    public async Task<IActionResult> RegistrarFuncionario(
        [FromServices] IRegistrarFuncionarioUseCase useCase,
        [FromBody] RequisicaoRegistrarFuncionarioJson requisicao)
    {
        var resultado = await useCase.Executar(requisicao);

        return Created(string.Empty, resultado);
    }

}
