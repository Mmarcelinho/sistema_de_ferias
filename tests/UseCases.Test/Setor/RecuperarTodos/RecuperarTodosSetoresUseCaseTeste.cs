using SistemaDeFerias.Application.UseCases.Setor.RecuperarTodos;

namespace UseCases.Test.Setor.RecuperarTodos;

public class RecuperarTodosSetoresUseCaseTeste
{
    [Fact]
    public async Task Validar_Sucesso_Sem_Setores()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(setor);

        var resposta = await useCase.Executar();
        resposta.Setores.Clear();

        resposta.Setores.Should().HaveCount(0);
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(setor);

        var resposta = await useCase.Executar();

        resposta.Setores.Should().HaveCountGreaterThan(0);
    }


    private static RecuperarTodosSetoresUseCase CriarUseCase(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioRead = SetorReadOnlyRepositorioBuilder.Instancia().RecuperarTodos(setor).Construir();

        return new RecuperarTodosSetoresUseCase(mapper, repositorioRead);
    }
}
