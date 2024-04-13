namespace SistemaDeFerias.Api.Controllers;

public class LoginController : SistemaDeFeriasController
{
    [HttpPost]
    [Route("funcionario/")]
    [ProducesResponseType(typeof(RespostaLoginFuncionarioJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginFuncionario(
        [FromServices] ILoginFuncionarioUseCase useCase,
        [FromBody] RequisicaoLoginFuncionarioJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Ok(resposta);
    }

     [HttpPost]
     [Route("admin/")]
    [ProducesResponseType(typeof(RespostaLoginAdminJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginAdmin(
        [FromServices] ILoginAdminUseCase useCase,
        [FromBody] RequisicaoLoginAdminJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Ok(resposta);
    }

}
