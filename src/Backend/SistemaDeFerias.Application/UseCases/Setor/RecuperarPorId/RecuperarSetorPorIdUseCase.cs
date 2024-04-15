namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarPorId;

public class RecuperarSetorPorIdUseCase : IRecuperarSetorPorIdUseCase

{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly ISetorReadOnlyRepositorio _repositorio;

    public RecuperarSetorPorIdUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, ISetorReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
    }

    public async Task<RespostaSetorJson> Executar(long id)
    {
        var setor = await _repositorio.RecuperarPorId(id);

        Validar(setor);

        return _mapper.Map<RespostaSetorJson>(setor);
    }

    private static void Validar(Domain.Entidades.Setor setor)
    {
        if (setor is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO });
    }
}
