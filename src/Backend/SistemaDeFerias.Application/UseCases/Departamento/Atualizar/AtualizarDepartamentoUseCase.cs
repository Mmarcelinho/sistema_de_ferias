namespace SistemaDeFerias.Application.UseCases.Departamento.Atualizar;

public class AtualizarDepartamentoUseCase : IAtualizarDepartamentoUseCase
{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly IDepartamentoUpdateOnlyRepositorio _repositorio;

    public AtualizarDepartamentoUseCase(
        IMapper mapper, 
        IUnidadeDeTrabalho unidadeDeTrabalho, 
        IDepartamentoUpdateOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
    }

    public async Task Executar(long id, RequisicaoDepartamentoJson requisicao)
    {
        var departamento = await _repositorio.RecuperarPorId(id);

        Validar(departamento, requisicao);

        _mapper.Map(requisicao, departamento);

        _repositorio.Atualizar(departamento);

        await _unidadeDeTrabalho.Commit();
    }

    public static void Validar(Domain.Entidades.Departamento departamento, RequisicaoDepartamentoJson requisicao)
    {
        if (departamento is null)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.DEPARTAMENTO_NAO_ENCONTRADO});
        }


        var validator = new AtualizarDepartamentoValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}