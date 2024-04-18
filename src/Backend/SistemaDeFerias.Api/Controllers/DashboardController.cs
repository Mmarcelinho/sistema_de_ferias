namespace SistemaDeFerias.Api.Controllers;

public class DashboardController : SistemaDeFeriasController
{
    [HttpGet]
    [Route("funcionario")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosFuncionarioJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(FuncionarioAutenticadoAttribute))]
    public async Task<IActionResult> RecuperarDashboardPedidosFuncionario(
        [FromServices] IPedidosFuncionarioDashboardUseCase useCase)
    {
        var resultado = await useCase.Executar();

        if (resultado.Pedidos.Any())
            return Ok(resultado);

        return NoContent();
    }

    [HttpGet]
    [Route("admin")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosAdminJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(AdminAutenticadoAttribute))]
    public async Task<IActionResult> RecuperarDashboardPedidosAdmin(
        [FromServices] IPedidosAdminDashboardUseCase useCase)
    {
        var resultado = await useCase.Executar();

        if (resultado.Pedidos.Any())
            return Ok(resultado);

        return NoContent();
    }
}
