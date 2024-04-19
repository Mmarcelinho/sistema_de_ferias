namespace SistemaDeFerias.Api.Controllers;

public class DashboardController : SistemaDeFeriasController
{
    [HttpGet]
    [Route("funcionario")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosFuncionarioJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> RecuperarDashboardPedidosFuncionario(
        [FromServices] IPedidosFuncionarioDashboardUseCase useCase)
    {
        var resultado = await useCase.Executar();

        if (resultado.Pedidos.Count == 0)
            return Ok(resultado);

        return NoContent();
    }

    [HttpGet]
    [Route("admin")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosAdminJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Admin>))]
    public async Task<IActionResult> RecuperarDashboardPedidosAdmin(
        [FromServices] IPedidosAdminDashboardUseCase useCase)
    {
        var resultado = await useCase.Executar();

        if (resultado.Pedidos.Count == 0)
            return Ok(resultado);

        return NoContent();
    }
}
