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

}
