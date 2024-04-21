using SistemaDeFerias.Application.UseCases.Setor.Deletar;
using Utilitario.Testes.Domain.RepositorioSetor;

namespace UseCases.Test.Setor.Deletar;

public class DeletarSetorUseCaseTeste
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(1, setor);

        Func<Task> acao = async () => { await useCase.Executar(setor.Id); };

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Validar_Erro_Setor_Nao_Existe()
    {
        var setor = SetorBuilder.Construir(1);

        var useCase = CriarUseCase(1, setor);

        Func<Task> acao = async () => { await useCase.Executar(0); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(exception => exception.MensagensDeErro.Count == 1 && exception.MensagensDeErro.Contains(ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO));
    }

    private static DeletarSetorUseCase CriarUseCase(long id, SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        var mapper = MapperBuilder.Instancia();
        var repositorioWrite = SetorWriteOnlyRepositorioBuilder.Instancia().Construir();
        var repositorioRead = SetorReadOnlyRepositorioBuilder.Instancia().RecuperarPorId(setor).Construir();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();

        return new DeletarSetorUseCase(unidadeDeTrabalho, repositorioRead, repositorioWrite);
    }
}
