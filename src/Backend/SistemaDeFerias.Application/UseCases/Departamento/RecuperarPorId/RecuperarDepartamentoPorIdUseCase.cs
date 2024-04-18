namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorId;

public class RecuperarDepartamentoPorIdUseCase : IRecuperarDepartamentoPorIdUseCase

{
    private readonly IMapper _mapper;

    private readonly IDepartamentoReadOnlyRepositorio _repositorio;

    public RecuperarDepartamentoPorIdUseCase(IMapper mapper, IDepartamentoReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<RespostaDepartamentoJson> Executar(long id)
    {
        var departamento = await _repositorio.RecuperarPorId(id);

        Validar(departamento);

        return _mapper.Map<RespostaDepartamentoJson>(departamento);
    }

    private static void Validar(Domain.Entidades.Departamento departamento)
    {
        if (departamento is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO});
    }
}
