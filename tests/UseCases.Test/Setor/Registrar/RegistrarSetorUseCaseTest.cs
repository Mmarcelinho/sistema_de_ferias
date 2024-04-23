namespace UseCases.Test.Setor.Registrar;

public class RegistrarSetorUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var useCase = CriarUseCase();

        var requisicao = RequisicaoSetorBuilder.Construir();

        var resposta = await useCase.Executar(requisicao);

        resposta.Should().NotBeNull();

        resposta.Nome.Should().NotBeNullOrWhiteSpace();
        resposta.Nome.Should().Be(requisicao.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Nome_Setor_Vazio()
    {
        int setorId = 1;

        var setor = SetorBuilder.Construir(setorId);

        var useCase = CriarUseCase();

        var requisicao = RequisicaoSetorBuilder.Construir();
        var requisicaoSemNome = requisicao with { Nome = null };

        Func<Task> acao = async () => { await useCase.Executar(requisicaoSemNome); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.NOME_DO_SETOR_EMBRANCO));
    }

    private static RegistrarSetorUseCase CriarUseCase()
    {
        var mapper = MapperBuilder.Instancia();
        var repositorio = SetorWriteOnlyRepositorioBuilder.Instancia().Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new RegistrarSetorUseCase(mapper, unidadeDeTrabalho, repositorio);
    }
}
