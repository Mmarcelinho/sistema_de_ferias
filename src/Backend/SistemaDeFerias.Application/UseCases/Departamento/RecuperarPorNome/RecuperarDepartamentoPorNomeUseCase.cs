namespace SistemaDeFerias.Application.UseCases.Departamento.RecuperarPorNome;

public class RecuperarDepartamentoPorNomeUseCase : IRecuperarDepartamentoPorNomeUseCase

{
    private readonly IMapper _mapper;

    private readonly IDepartamentoReadOnlyRepositorio _repositorio;

    public RecuperarDepartamentoPorNomeUseCase(IMapper mapper, IDepartamentoReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _repositorio = repositorio;
    }

    public async Task<RespostaDepartamentoJson> Executar(string nome)
    {
        var departamento = await _repositorio.RecuperarPorNome(nome);

        Validar(departamento);

        return _mapper.Map<RespostaDepartamentoJson>(departamento);
    }

    private static void Validar(Domain.Entidades.Departamento departamento)
    {
        if (departamento is null)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO });
    }
}
