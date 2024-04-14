namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;

public class AnalisarPedidoFeriasUseCase : IAnalisarPedidoFeriasUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IAdminLogado _adminLogado;
    private readonly IPedidoFeriasUpdateOnlyRepositorio _repositorio;

    public AnalisarPedidoFeriasUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, IAdminLogado adminLogado, IPedidoFeriasUpdateOnlyRepositorio repositorio)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _adminLogado = adminLogado;
        _repositorio = repositorio;
    }

    public async Task<RespostaPedidoFeriasAnalisadoJson> Executar(long id, RequisicaoAnalisarPedidoFeriasJson requisicao)
    {
        var admin = await _adminLogado.RecuperarAdmin();
        var pedido = await _repositorio.RecuperarPorId(id);

        Validar(pedido,requisicao);
        ValidarStatus(pedido);

        _mapper.Map(requisicao, pedido);
        pedido.AdminId = admin.Id;

        _repositorio.Atualizar(pedido);

        await _unidadeDeTrabalho.Commit();

        return _mapper.Map<RespostaPedidoFeriasAnalisadoJson>(pedido);
    }

    private static void Validar(Domain.Entidades.PedidoFerias pedido, RequisicaoAnalisarPedidoFeriasJson requisicao)
    {
        if(pedido is null)
        throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO});

        var validator = new AnalisarPedidoFeriasValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagesDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }

    private static bool ValidarStatus(Domain.Entidades.PedidoFerias pedido)
    {
        if(pedido.Status == Domain.Enum.Status.Aprovado)
        throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_APROVADO});

        else if(pedido.Status == Domain.Enum.Status.Negado)
        throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_NEGADO});

        return true;
    }
}
