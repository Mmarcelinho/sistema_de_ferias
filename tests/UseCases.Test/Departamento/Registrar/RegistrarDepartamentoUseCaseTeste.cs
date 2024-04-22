namespace UseCases.Test.Setor.Registrar;

public class RegistrarDepartamentoUseCaseTeste
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int setorId = 1;

        var useCase = CriarUseCase();

        var requisicao = RequisicaoDepartamentoBuilder.Construir(setorId);

        var resposta = await useCase.Executar(requisicao);

        resposta.Should().NotBeNull();
        resposta.Nome.Should().NotBeNullOrWhiteSpace();
        resposta.Nome.Should().Be(requisicao.Nome);
    }

    [Fact]
    public async Task Validar_Erro_Nome_Departamento_Vazio()
    {
        int setorId = 1;

        var useCase = CriarUseCase();

        var requisicao = RequisicaoDepartamentoBuilder.Construir(setorId);
        var requisicaoSemNome = requisicao with { Nome = null };

        Func<Task> acao = async () => { await useCase.Executar(requisicaoSemNome); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.NOME_DO_DEPARTAMENTO_EMBRANCO));
    }

    private static RegistrarDepartamentoUseCase CriarUseCase()
    {
        var mapper = MapperBuilder.Instancia();
        var repositorio = DepartamentoWriteOnlyRepositorioBuilder.Instancia().Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new RegistrarDepartamentoUseCase(mapper, unidadeDeTrabalho, repositorio);
    }
}
