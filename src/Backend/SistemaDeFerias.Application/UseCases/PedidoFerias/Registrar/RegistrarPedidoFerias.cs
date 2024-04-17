namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Registrar;

public class RegistrarPedidoFeriasUseCase : IRegistrarPedidoFeriasUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IFuncionarioLogado _funcionarioLogado;
    private readonly IPedidoFeriasWriteOnlyRepositorio _repositorio;

    public RegistrarPedidoFeriasUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, IFuncionarioLogado funcionarioLogado, IPedidoFeriasWriteOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _funcionarioLogado = funcionarioLogado;
        _repositorio = repositorio;
    }

    public async Task<RespostaPedidoFeriasSolicitacaoJson> Executar(RequisicaoSolicitarPedidoFeriasJson requisicao)
    {
        Validar(requisicao);

        var funcionarioLogado = await _funcionarioLogado.RecuperarFuncionario();

        ValidarFerias(funcionarioLogado.DataEntrada, funcionarioLogado.DataUltimaFerias);

        var pedido = _mapper.Map<Domain.Entidades.PedidoFerias>(requisicao);

        pedido.FuncionarioId = funcionarioLogado.Id;
        pedido.Status = Domain.Enum.Status.Pendente;
        pedido.DataPedido = DateTime.UtcNow;
        pedido.DataFim = pedido.DataInicio.AddDays(pedido.Dias);

        await _repositorio.Registrar(pedido);

        await _unidadeDeTrabalho.Commit();

        return _mapper.Map<RespostaPedidoFeriasSolicitacaoJson>(pedido);
    }

    private static void Validar(RequisicaoSolicitarPedidoFeriasJson requisicao)
    {
        var validator = new RegistrarPedidoFeriasValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagesDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }

    private static void ValidarFerias(DateTime dataEntrada, DateTime? dataUltimaFerias)
    {
        if (!ElegivelParaFerias(dataEntrada, dataUltimaFerias))
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.FUNCIONARIO_NAO_ELEGIVEL_PARA_FERIAS });
    }

    private static bool ElegivelParaFerias(DateTime dataEntrada, DateTime? dataUltimaFerias)
    {

        if (dataUltimaFerias.HasValue)
        {
            var diasTrabalhadosPosUltimasFerias = DateTime.Today.Subtract(dataUltimaFerias.Value).TotalDays;
            return diasTrabalhadosPosUltimasFerias >= 365;
        }
        else
        {

            var diasTrabalhadosDesdeEntrada = DateTime.Today.Subtract(dataEntrada).TotalDays;
            return diasTrabalhadosDesdeEntrada >= 365;
        }
    }


}
