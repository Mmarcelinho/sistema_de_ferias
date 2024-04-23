namespace UseCases.Test.Setor.RecuperarPorId;

public class RecuperarDepartamentoPorIdUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var resposta = await useCase.Executar(departamento.Id);

        resposta.Nome.Should().Be(departamento.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Departamento_Nao_Existe()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        Func<Task> acao = async () => { await useCase.Executar(0); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO));
    }

    private static RecuperarDepartamentoPorIdUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = DepartamentoReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(departamento).Construir();

        return new RecuperarDepartamentoPorIdUseCase(mapper, repositorioRead);
    }
}
