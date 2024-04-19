namespace SistemaDeFerias.Api.Controllers;

public class FuncionarioController : SistemaDeFeriasController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaFuncionarioRegistradoJson), StatusCodes.Status201Created)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Admin>))]
    public async Task<IActionResult> RegistrarFuncionario(
        [FromServices] IRegistrarFuncionarioUseCase useCase,
        [FromBody] RequisicaoRegistrarFuncionarioJson requisicao)
    {
        var resultado = await useCase.Executar(requisicao);

        return Created(string.Empty, resultado);
    }

    [HttpPut]
    [Route("alterar-senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> AlterarSenha(
        [FromServices] IAlterarSenhaFuncionarioUseCase useCase,
        [FromBody] RequisicaoAlterarSenhaJson requisicao)
    {
        await useCase.Executar(requisicao);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(RespostaPerfilFuncionarioJson), StatusCodes.Status200OK)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute<Domain.Entidades.Funcionario>))]
    public async Task<IActionResult> RecuperarPerfil(
        [FromServices] IRecuperarPerfilFuncionarioUseCase useCase)
    {
        var resultado = await useCase.Executar();

        return Ok(resultado);
    }

}
