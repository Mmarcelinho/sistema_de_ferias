namespace UseCases.Test.Departamento.Atualizar;

public class AtualizarDepartamentoUseCaseTeste
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int departamentoId = 1;
        long setorId = 0;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var requisicao = RequisicaoDepartamentoBuilder.Construir(setorId);

        await useCase.Executar(departamento.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(departamentoId, requisicao); };

        await acao.Should().NotThrowAsync();

        departamento.Nome.Should().Be(requisicao.Nome);
        departamento.SetorId.Should().Be(requisicao.SetorId);
    }

    [Fact]
    public async Task Validar_Erro_Departamento_Nao_Existe()
    {
        int departamentoId = 1;
        long setorId = 0;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var requisicao = RequisicaoDepartamentoBuilder.Construir(setorId);

        await useCase.Executar(departamento.Id, requisicao);

        Func<Task> acao = async () => { await useCase.Executar(0, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO));
    }

    [Fact]
    public async Task Validar_Erro_Setor_Invalido()
    {
        int departamentoId = 1;
        long setorId = 0;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var requisicao = RequisicaoDepartamentoBuilder.Construir(setorId);

        Func<Task> acao = async () => { await useCase.Executar(departamentoId, requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.SETOR_INVALIDO));
    }

    private static AtualizarDepartamentoUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorio = DepartamentoUpdateOnlyRepositorioBuilder.Instancia().RecuperarPorId(departamento).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new AtualizarDepartamentoUseCase(mapper, unidadeDeTrabalho, repositorio);
    }
}
