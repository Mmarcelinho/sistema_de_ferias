namespace SistemaDeFerias.Application.UseCases.Dashboard.Admin.PedidosAdmin;

public class PedidosAdminDashboardUseCase : IPedidosAdminDashboardUseCase
{
    private readonly IPedidoFeriasReadOnlyRepositorio _repositorio;
    private readonly IAdminLogado _adminLogado;
    private readonly IMapper _mapper;

    public PedidosAdminDashboardUseCase(
        IPedidoFeriasReadOnlyRepositorio repositorio,
        IAdminLogado adminLogado,
        IMapper mapper)
    {
        _mapper = mapper;
        _repositorio = repositorio;
        _adminLogado = adminLogado;
    }

    public async Task<RespostaDashboardAdminJson> Executar()
    {
        var adminLogado = await _adminLogado.RecuperarUsuario();

        var pedidos = await _repositorio.RecuperarTodasDoAdmin(adminLogado.Id);

        pedidos = Ordenar(pedidos);

        return new RespostaDashboardAdminJson
        {
            Pedidos = _mapper.Map<List<RespostaDashboardPedidosAdminJson>>(pedidos)
        };
    }

    private static List<Domain.Entidades.PedidoFerias> Ordenar(IList<Domain.Entidades.PedidoFerias> pedidos)
    {
        if (pedidos is null)
            return new List<Domain.Entidades.PedidoFerias>();

        return pedidos.OrderByDescending(p => p.Id).ToList();
    }
}
