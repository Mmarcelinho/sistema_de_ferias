namespace SistemaDeFerias.Application.UseCases.Dashboard.Funcionario.PedidosFuncionario;

public class PedidosFuncionarioDashboardUseCase : IPedidosFuncionarioDashboardUseCase
{
    private readonly IPedidoFeriasReadOnlyRepositorio _repositorio;
    private readonly IFuncionarioLogado _funcionarioLogado;
    private readonly IMapper _mapper;

    public PedidosFuncionarioDashboardUseCase(
        IPedidoFeriasReadOnlyRepositorio repositorio,
        IFuncionarioLogado funcionarioLogado,
        IMapper mapper)
    {
        _mapper = mapper;
        _repositorio = repositorio;
        _funcionarioLogado = funcionarioLogado;
    }

    public async Task<RespostaDashboardFuncionarioJson> Executar()
    {
        var funcionarioLogado = await _funcionarioLogado.RecuperarUsuario();

        var pedidos = await _repositorio.RecuperarTodasDoFuncionario(funcionarioLogado.Id);

        pedidos = Ordenar(pedidos);

        return new RespostaDashboardFuncionarioJson
        {
            Pedidos = _mapper.Map<List<RespostaDashboardPedidosFuncionarioJson>>(pedidos)
        };
    }

    private static List<Domain.Entidades.PedidoFerias> Ordenar(IList<Domain.Entidades.PedidoFerias> pedidos)
    {
        if (pedidos is null)
            return new List<Domain.Entidades.PedidoFerias>();

        return pedidos.OrderByDescending(p => p.Id).ToList();
    }
}
