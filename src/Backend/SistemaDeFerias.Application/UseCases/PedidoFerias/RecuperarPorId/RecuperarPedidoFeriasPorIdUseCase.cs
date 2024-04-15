namespace SistemaDeFerias.Application.UseCases.PedidoFerias.RecuperarPorId;

    public class RecuperarPedidoFeriasPorIdUseCase : IRecuperarPedidoFeriasPorIdUseCase
    {
        private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    private readonly IFuncionarioLogado _funcionarioLogado;

    private readonly IPedidoFeriasReadOnlyRepositorio _repositorio;

    public RecuperarPedidoFeriasPorIdUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, IFuncionarioLogado funcionarioLogado, IPedidoFeriasReadOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _funcionarioLogado = funcionarioLogado;
        _repositorio = repositorio;
    }

    public async Task<RespostaPedidoFeriasJson> Executar(long id)
    {
        var funcionario = await _funcionarioLogado.RecuperarFuncionario();
        var pedido = await _repositorio.RecuperarPorId(id);

        Validar(funcionario,pedido);

        return _mapper.Map<RespostaPedidoFeriasJson>(pedido);
    }

    private static void Validar(Domain.Entidades.Funcionario funcionario ,Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido is null || pedido.FuncionarioId != funcionario.Id)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO });
    }
}
