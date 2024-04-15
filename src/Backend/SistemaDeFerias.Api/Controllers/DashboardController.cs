using SistemaDeFerias.Application.UseCases.Dashboard.Funcionario.PedidosFuncionario;

namespace SistemaDeFerias.Api.Controllers;

public class DashboardController : SistemaDeFeriasController
{
    [HttpGet]
    [ProducesResponseType(typeof(RespostaDashboardPedidosFuncionarioJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ServiceFilter(typeof(FuncionarioAutenticadoAttribute))]
    public async Task<IActionResult> RecuperarDashboardPedidosFuncionario(
        [FromServices] IPedidosFuncionarioDashboardUseCase useCase)
    {
        var resultado = await useCase.Executar();

        return Ok(resultado);
    }
}
