using SistemaDeFerias.Application.UseCases.Login.FazerLogin;
using SistemaDeFerias.Comunicacao.Requisicoes.Usuario;
using SistemaDeFerias.Comunicacao.Respostas.Usuario;

namespace SistemaDeFerias.Api.Controllers;

public class LoginController : SistemaDeFeriasController
{
    [HttpPost]
    [Route("funcionario/")]
    [ProducesResponseType(typeof(RespostaLoginUsuarioJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginFuncionario(
        [FromServices] ILoginUsuarioUseCase<Domain.Entidades.Funcionario> useCase,
        [FromBody] RequisicaoLoginUsuarioJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Ok(resposta);
    }

    [HttpPost]
    [Route("admin/")]
    [ProducesResponseType(typeof(RespostaLoginUsuarioJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginAdmin(
        [FromServices] ILoginUsuarioUseCase<Domain.Entidades.Admin> useCase,
        [FromBody] RequisicaoLoginUsuarioJson requisicao)
    {
        var resposta = await useCase.Executar(requisicao);

        return Ok(resposta);
    }

}
