namespace SistemaDeFerias.Api.Controllers;

[ServiceFilter(typeof(AdminAutenticadoAttribute))]
public class AdminController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaAdminRegistradoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarAdmin(
        [FromServices] IRegistrarAdminUseCase useCase,
        [FromBody] RequisicaoRegistrarAdminJson requisicao)
    {
        var resultado = await useCase.Executar(requisicao);

        return Created(string.Empty, resultado);
    }

    [HttpPut]
    [Route("alterar-senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(AdminAutenticadoAttribute))]
    public async Task<IActionResult> AlterarSenha(
        [FromServices] IAlterarSenhaAdminUseCase useCase,
        [FromBody] RequisicaoAlterarSenhaJson requisicao)
    {
        await useCase.Executar(requisicao);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(RespostaPerfilAdminJson), StatusCodes.Status200OK)]
    [ServiceFilter(typeof(AdminAutenticadoAttribute))]
    public async Task<IActionResult> RecuperarPerfil(
        [FromServices] IRecuperarPerfilAdminUseCase useCase)
    {
        var resultado = await useCase.Executar();

        return Ok(resultado);
    }

}
