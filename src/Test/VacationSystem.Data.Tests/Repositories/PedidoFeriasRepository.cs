namespace VacationSystem.Data.Tests.Repositories;

public class PedidoFeriasRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public PedidoFeriasRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var pedidoFerias = await _unitOfWork.PedidoFeriasRepository.ObterTodosAsync();
        pedidoFerias.Should().HaveCount(4);
    }

    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_PedidoFerias()
    {
        var pedidoFerias = new PedidoFerias(5, 5, DateTime.Now, DateTime.Now, 5);
        int objetoId = (int)await _unitOfWork.PedidoFeriasRepository.AdicionarAsync(pedidoFerias);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_PedidoFerias()
    {
        var novoStatus = "Aprovado";
        var pedidoFerias = await _unitOfWork.PedidoFeriasRepository.ObterPorIdAsync(4);

        pedidoFerias.Atualizar(novoStatus);
        _unitOfWork.PedidoFeriasRepository.AtualizarAsync(pedidoFerias);
        await _unitOfWork.CommitAsync();

        pedidoFerias.Status.Should().Be(novoStatus);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_PedidoFerias()
    {
        var id = 1;
        await _unitOfWork.PedidoFeriasRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var pedidoFeriasExcluido = await _unitOfWork.PedidoFeriasRepository.ObterPorIdAsync(id);
        pedidoFeriasExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.PedidoFeriasRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
