namespace UseCases.Test.Setor.Atualizar;

public class AtualizarSetorUseCaseTest
{

    [Fact]
    public async Task Validar_Sucesso()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(1, setor);

        var requisicao = RequisicaoSetorBuilder.Construir();

        await useCase.Executar(setor.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(1, requisicao); };

        await acao.Should().NotThrowAsync();

        setor.Nome.Should().Be(requisicao.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Setor_Nao_Existe()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(1, setor);

        var requisicao = RequisicaoSetorBuilder.Construir();

        await useCase.Executar(setor.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(0, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO));
    }

    private static AtualizarSetorUseCase CriarUseCase(long id, SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorio = SetorUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(setor).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new AtualizarSetorUseCase(mapper, unidadeDeTrabalho, repositorio);
    }
}
