namespace SistemaDeFerias.Api.Controllers;

public class DashboardController : SistemaDeFeriasController
{
    [HttpGet]
    [Route("funcionario")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosFuncionarioJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> RecuperarDashboardPedidosFuncionario(
        [FromServices] IPedidosFuncionarioDashboardUseCase useCase)
    {
        var resposta = await useCase.Executar();

        if (resposta.Pedidos.Count == 0)
            return NoContent();

        return Ok(resposta);
    }

    [HttpGet]
    [Route("admin")]
    [ProducesResponseType(typeof(RespostaDashboardPedidosAdminJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Admin>))]
    public async Task<IActionResult> RecuperarDashboardPedidosAdmin(
        [FromServices] IPedidosAdminDashboardUseCase useCase)
    {
        var resposta = await useCase.Executar();

        if (resposta.Pedidos.Count == 0)
            return NoContent();

        return Ok(resposta);
    }
}
