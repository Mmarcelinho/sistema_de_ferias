namespace SistemaDeFerias.Application.UseCases.Setor.Deletar;

public class DeletarSetorUseCase : IDeletarSetorUseCase

{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    ISetorWriteOnlyRepositorio _repositorioWriteOnly;

    private readonly ISetorReadOnlyRepositorio _repositorioReadOnly;

    public DeletarSetorUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, ISetorReadOnlyRepositorio repositorioReadOnly, ISetorWriteOnlyRepositorio repositorioWriteOnly)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
       _repositorioReadOnly = repositorioReadOnly;
       _repositorioWriteOnly = repositorioWriteOnly;
    }

    public async Task Executar(long id)
    {
        var setor = await _repositorioReadOnly.RecuperarPorId(id);

        Validar(setor);

        await _repositorioWriteOnly.Deletar(id);

        await _unidadeDeTrabalho.Commit();
    }

    private static void Validar(Domain.Entidades.Setor setor)
    {
        if (setor is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO });
    }
}
