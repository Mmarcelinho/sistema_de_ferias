namespace SistemaDeFerias.Application.UseCases.Departamento.Registrar;

public class RegistrarDepartamentoUseCase : IRegistrarDepartamentoUseCase
{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly IDepartamentoWriteOnlyRepositorio _repositorio;

    public RegistrarDepartamentoUseCase(
        IMapper mapper, 
        IUnidadeDeTrabalho unidadeDeTrabalho, 
        IDepartamentoWriteOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
    }

    public async Task<RespostaDepartamentoJson> Executar(RequisicaoDepartamentoJson requisicao)
    {
        Validar(requisicao);

        var departamento = _mapper.Map<Domain.Entidades.Departamento>(requisicao);

        await _repositorio.Registrar(departamento);

        await _unidadeDeTrabalho.Commit();

        return _mapper.Map<RespostaDepartamentoJson>(departamento);
    }

    private static void Validar(RequisicaoDepartamentoJson requisicao)
    {
        var validator = new RegistrarDepartamentoValidator();

        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}
