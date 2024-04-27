namespace UseCases.Test.Usuario.Funcionario.RecuperarPerfil;

public class RecuperarPerfilFuncionarioUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var funcionario, _) = FuncionarioBuilder.Construir();

        var useCase = CriarUseCase(funcionario);

        var resposta = await useCase.Executar();

        resposta.Should().NotBeNull();
        resposta.Nome.Should().Be(funcionario.Nome);
        resposta.Email.Should().Be(funcionario.Email);
        resposta.Telefone.Should().Be(funcionario.Telefone);
    }

    private static RecuperarPerfilFuncionarioUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Funcionario funcionario)
    {
        var mapper = MapperBuilder.Instancia();
        var funcionarioLogado = FuncionarioLogadoBuilder.Instancia().RecuperarUsuario(funcionario).Construir();

        return new RecuperarPerfilFuncionarioUseCase(mapper, funcionarioLogado);
    }
}
