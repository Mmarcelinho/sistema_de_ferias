namespace UseCases.Test.Setor.Deletar;

public class DeletarSetorUseCaseTeste
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int setorId = 1;

        var setor = SetorBuilder.Construir(setorId);

        var useCase = CriarUseCase(setor);

        Func<Task> acao = async () => { await useCase.Executar(setor.Id); };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Erro_Setor_Nao_Existe()
    {
        int setorId = 1;

        var setor = SetorBuilder.Construir(setorId);

        var useCase = CriarUseCase(setor);

        Func<Task> acao = async () => { await useCase.Executar(0); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO));
    }

    private static DeletarSetorUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        var repositorioWrite = SetorWriteOnlyRepositorioBuilder.Instancia().Construir();
        var repositorioRead = SetorReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(setor).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new DeletarSetorUseCase(unidadeDeTrabalho, repositorioRead, repositorioWrite);
    }
}
