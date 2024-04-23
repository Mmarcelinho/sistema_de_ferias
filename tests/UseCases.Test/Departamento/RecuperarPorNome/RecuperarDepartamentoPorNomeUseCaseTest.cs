namespace UseCases.Test.Setor.RecuperarPorNome;

public class RecuperarDepartamentoPorNomeUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var resposta = await useCase.Executar(departamento.Nome);

        resposta.Nome.Should().Be(departamento.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Departamento_Nao_Existe()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        Func<Task> acao = async () => { await useCase.Executar(""); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO));
    }

    private static RecuperarDepartamentoPorNomeUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = DepartamentoReadOnlyRepositorioBuilder.Instancia().RecuperarPorNome(departamento).Construir();

        return new RecuperarDepartamentoPorNomeUseCase(mapper, repositorioRead);
    }
}
