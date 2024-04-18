namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarTodos;

public class RecuperarTodosDepartamentosUseCase : IRecuperarTodosDepartamentosUseCase

{
    private readonly IMapper _mapper;

    private readonly IDepartamentoReadOnlyRepositorio _repositorio;

    public RecuperarTodosDepartamentosUseCase(IMapper mapper, IDepartamentoReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<RespostaDepartamentoListJson> Executar()
    {
        var departamentos = await _repositorio.RecuperarTodos();

        departamentos = Validar(departamentos);

        return new RespostaDepartamentoListJson
        {
            Departamentos = _mapper.Map<List<RespostaDepartamentoJson>>(departamentos)
        };
    }

    private static IList<Domain.Entidades.Departamento> Validar(IList<Domain.Entidades.Departamento> departamentos)
    {
        if (departamentos is null)
            return new List<Domain.Entidades.Departamento>();

        return departamentos;
    }
}
