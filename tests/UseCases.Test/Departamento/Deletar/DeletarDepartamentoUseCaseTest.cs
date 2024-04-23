namespace UseCases.Test.Setor.Deletar;

public class DeletarDepartamentoUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        Func<Task> acao = async () => { await useCase.Executar(departamento.Id); };

        await acao.Should().NotThrowAsync();
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

    private static DeletarDepartamentoUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        var repositorioWrite = DepartamentoWriteOnlyRepositorioBuilder.Instancia().Construir();
        var repositorioRead = DepartamentoReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(departamento).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new DeletarDepartamentoUseCase(unidadeDeTrabalho, repositorioRead, repositorioWrite);
    }
}
