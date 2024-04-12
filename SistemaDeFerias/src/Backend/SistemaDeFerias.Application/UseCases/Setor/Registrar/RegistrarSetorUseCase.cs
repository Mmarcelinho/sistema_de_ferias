namespace SistemaDeFerias.Application.UseCases.Setor.Registrar;

public class RegistrarSetorUseCase : IRegistrarSetorUseCase
{
    private readonly IMapper _mapper;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly ISetorWriteOnlyRepositorio _repositorio;

    public RegistrarSetorUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, ISetorWriteOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repositorio = repositorio;
    }

    public async Task<RespostaSetorJson> Executar(RequisicaoSetorJson requisicao)
    {
        Validar(requisicao);

        var setor = _mapper.Map<Domain.Entidades.Setor>(requisicao);

        await _repositorio.Registrar(setor);

        await _unidadeDeTrabalho.Commit();

        return _mapper.Map<RespostaSetorJson>(setor);
    }

    private static void Validar(RequisicaoSetorJson requisicao)
    {
        var validator = new RegistrarSetorValidator();

        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}
