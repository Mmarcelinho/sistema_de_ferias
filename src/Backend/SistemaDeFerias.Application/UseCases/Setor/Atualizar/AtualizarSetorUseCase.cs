namespace SistemaDeFerias.Application.UseCases.Setor.Atualizar;

public class AtualizarSetorUseCase : IAtualizarSetorUseCase
{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly ISetorUpdateOnlyRepositorio _repositorio;

    public AtualizarSetorUseCase(
    IMapper mapper, 
    IUnidadeDeTrabalho unidadeDeTrabalho, 
    ISetorUpdateOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
    }

    public async Task Executar(long id, RequisicaoSetorJson requisicao)
    {
        var setor = await _repositorio.RecuperarPorId(id);

        Validar(setor, requisicao);

        _mapper.Map(requisicao, setor);

        _repositorio.Atualizar(setor);

        await _unidadeDeTrabalho.Commit();
    }

    public static void Validar(Domain.Entidades.Setor setor, RequisicaoSetorJson requisicao)
    {
        if (setor is null)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.SETOR_NAO_ENCONTRADO });
        }


        var validator = new AtualizarSetorValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}