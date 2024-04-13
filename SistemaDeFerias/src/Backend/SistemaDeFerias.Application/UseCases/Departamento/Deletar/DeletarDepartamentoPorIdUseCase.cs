namespace SistemaDeFerias.Application.UseCases.Departamento.Deletar;

public class DeletarDepartamentoUseCase : IDeletarDepartamentoUseCase

{
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    IDepartamentoWriteOnlyRepositorio _repositorioWriteOnly;

    private readonly IDepartamentoReadOnlyRepositorio _repositorioReadOnly;

    public DeletarDepartamentoUseCase(IUnidadeDeTrabalho unidadeDeTrabalho, IDepartamentoReadOnlyRepositorio repositorioReadOnly, IDepartamentoWriteOnlyRepositorio repositorioWriteOnly)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
       _repositorioReadOnly = repositorioReadOnly;
       _repositorioWriteOnly = repositorioWriteOnly;
    }

    public async Task Executar(long id)
    {
        var departamento = await _repositorioReadOnly.RecuperarPorId(id);

        Validar(departamento);

        await _repositorioWriteOnly.Deletar(id);

        await _unidadeDeTrabalho.Commit();
    }

    private static void Validar(Domain.Entidades.Departamento departamento)
    {
        if (departamento is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO });
    }
}
