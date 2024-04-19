namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Analisar;

public class AnalisarPedidoFeriasUseCase : IAnalisarPedidoFeriasUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IAdminLogado _adminLogado;
    private readonly IPedidoFeriasUpdateOnlyRepositorio _repositorio;

    private readonly IFuncionarioReadOnlyRepositorio _repositorioFuncionarioRead;

    private readonly IFuncionarioUpdateOnlyRepositorio _repositorioFuncionarioUpdate;

    public AnalisarPedidoFeriasUseCase(
        IMapper mapper, 
        IUnidadeDeTrabalho unidadeDeTrabalho, 
        IAdminLogado adminLogado, 
        IPedidoFeriasUpdateOnlyRepositorio repositorio,
        IFuncionarioUpdateOnlyRepositorio repositorioFuncionarioUpdate)
    {
        _mapper = mapper;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _adminLogado = adminLogado;
        _repositorio = repositorio;
        _repositorioFuncionarioUpdate = repositorioFuncionarioUpdate;
    }

    public async Task Executar(long id, RequisicaoAnalisarPedidoFeriasJson requisicao)
    {
        var admin = await _adminLogado.RecuperarUsuario();
        var pedido = await _repositorio.RecuperarPorId(id);
        var funcionario = await _repositorioFuncionarioUpdate.RecuperarPorId(pedido.FuncionarioId);

        Validar(pedido, requisicao);
        ValidarStatus(pedido);
        
        _mapper.Map(requisicao, pedido);
        pedido.AdminId = admin.Id;

        AtribuirUltimaFerias(funcionario,pedido);

        _repositorio.Atualizar(pedido);
        _repositorioFuncionarioUpdate.Atualizar(funcionario);
        await _unidadeDeTrabalho.Commit();
    }

    private static void Validar(Domain.Entidades.PedidoFerias pedido, RequisicaoAnalisarPedidoFeriasJson requisicao)
    {
        if (pedido is null)
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO });

        var validator = new AnalisarPedidoFeriasValidator();
        var resultado = validator.Validate(requisicao);

        if (!resultado.IsValid)
        {
            var mensagesDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagesDeErro);
        }
    }

    private static void ValidarStatus(Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido.Status == Domain.Enum.Status.Aprovado)
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_APROVADO });

        else if (pedido.Status == Domain.Enum.Status.Negado)
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.ALTERAR_STATUS_DE_SOLICITACAO_NEGADO });
    }

    private static void AtribuirUltimaFerias(Domain.Entidades.Funcionario funcionario, Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido.Status == Domain.Enum.Status.Aprovado)
            funcionario.DataUltimaFerias = pedido.DataInicio;
    }
}
