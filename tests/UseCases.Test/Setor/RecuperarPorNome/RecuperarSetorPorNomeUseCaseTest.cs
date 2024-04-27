namespace UseCases.Test.Setor.RecuperarPorNome;

public class RecuperarSetorPorNomeUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int setorId = 1;

        var setor = SetorBuilder.Construir(setorId);

        var useCase = CriarUseCase(setor);

        var resposta = await useCase.Executar(setor.Nome);

        resposta.Nome.Should().Be(setor.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Setor_Nao_Existe()
    {
        int setorId = 1;

        var setor = SetorBuilder.Construir(setorId);

        var useCase = CriarUseCase(setor);

        Func<Task> acao = async () => { await useCase.Executar(""); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO));
    }

    private static RecuperarSetorPorNomeUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = SetorReadOnlyRepositorioBuilder.Instancia().RecuperarPorNome(setor).Construir();

        return new RecuperarSetorPorNomeUseCase(mapper, repositorioRead);
    }
}
