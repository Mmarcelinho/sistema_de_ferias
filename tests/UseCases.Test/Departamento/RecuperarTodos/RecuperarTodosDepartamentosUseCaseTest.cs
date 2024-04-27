namespace UseCases.Test.Setor.RecuperarTodos;

public class RecuperarTodosDepartamentosUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso_Sem_Departamentos()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var resposta = await useCase.Executar();
        resposta.Departamentos.Clear();

        resposta.Departamentos.Should().HaveCount(0);
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        int departamentoId = 1;

        var departamento = DepartamentoBuilder.Construir(departamentoId);

        var useCase = CriarUseCase(departamento);

        var resposta = await useCase.Executar();

        resposta.Departamentos.Should().HaveCountGreaterThan(0);
    }


    private static RecuperarTodosDepartamentosUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = DepartamentoReadOnlyRepositorioBuilder.Instancia().RecuperarTodos(departamento).Construir();

        return new RecuperarTodosDepartamentosUseCase(mapper, repositorioRead);
    }
}
