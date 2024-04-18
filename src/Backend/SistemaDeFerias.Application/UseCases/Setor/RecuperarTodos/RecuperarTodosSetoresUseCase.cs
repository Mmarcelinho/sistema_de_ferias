namespace SistemaDeFerias.Application.UseCases.Setor.RecuperarTodos;

public class RecuperarTodosSetoresUseCase : IRecuperarTodosSetoresUseCase

{
    private readonly IMapper _mapper;

    private readonly ISetorReadOnlyRepositorio _repositorio;

    public RecuperarTodosSetoresUseCase(IMapper mapper, ISetorReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<RespostaSetorListJson> Executar()
    {
        var setores = await _repositorio.RecuperarTodos();

        Validar(setores);

        return new RespostaSetorListJson
        {
            Setores = _mapper.Map<List<RespostaSetorJson>>(setores)
        };
    }

    private static IList<Domain.Entidades.Setor> Validar(IList<Domain.Entidades.Setor> setores)
    {
        if (setores is null)
            return new List<Domain.Entidades.Setor>();

        return setores;
    }
}
