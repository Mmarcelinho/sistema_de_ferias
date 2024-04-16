namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarPorNome;

public class RecuperarSetorPorNomeUseCase : IRecuperarSetorPorNomeUseCase

{
    private readonly IMapper _mapper;

    private readonly ISetorReadOnlyRepositorio _repositorio;

    public RecuperarSetorPorNomeUseCase(IMapper mapper, ISetorReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<RespostaSetorJson> Executar(string nome)
    {
        var setor = await _repositorio.RecuperarPorNome(nome);

        Validar(setor);

        return _mapper.Map<RespostaSetorJson>(setor);
    }

    private static void Validar(Domain.Entidades.Setor setor)
    {
        if (setor is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO });
    }
}
