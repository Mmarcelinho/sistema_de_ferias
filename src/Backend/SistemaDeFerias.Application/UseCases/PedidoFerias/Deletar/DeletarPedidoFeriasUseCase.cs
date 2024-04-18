namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Deletar;

public class DeletarPedidoFeriasUseCase : IDeletarPedidoFeriasUseCase
{
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IFuncionarioLogado _funcionarioLogado;
    private readonly IPedidoFeriasWriteOnlyRepositorio _repositorioWriteOnly;

    private readonly IPedidoFeriasReadOnlyRepositorio _repositorioReadOnly;

    public DeletarPedidoFeriasUseCase(IUnidadeDeTrabalho unidadeDeTrabalho, IFuncionarioLogado funcionarioLogado, IPedidoFeriasWriteOnlyRepositorio repositorioWriteOnly, IPedidoFeriasReadOnlyRepositorio repositorioReadOnly)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _funcionarioLogado = funcionarioLogado;
        _repositorioReadOnly = repositorioReadOnly;
        _repositorioWriteOnly = repositorioWriteOnly;
    }

    public async Task Executar(long id)
    {
        var funcionario = await _funcionarioLogado.RecuperarFuncionario();
        var pedido = await _repositorioReadOnly.RecuperarPorId(id);

        Validar(funcionario, pedido);
        ValidarStatus(pedido);

        await _repositorioWriteOnly.Deletar(id);

        await _unidadeDeTrabalho.Commit();
    }

    private static void Validar(Domain.Entidades.Funcionario funcionario ,Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido is null || pedido.FuncionarioId != funcionario.Id)

            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO });
    }
    private static bool ValidarStatus(Domain.Entidades.PedidoFerias pedido)
    {
        if (pedido.Status == Domain.Enum.Status.Aprovado || pedido.Status == Domain.Enum.Status.Negado)
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.REMOVER_PEDIDO_ANALISADO});

        return true;
    }
}
