namespace VacationSystem.Data.Tests.Repositories;

public class DepartamentoRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public DepartamentoRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var departamentos = await _unitOfWork.DepartamentoRepository.ObterTodosAsync();
        departamentos.Should().HaveCount(4);
    }

    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Departamento()
    {
        var departamento = new Departamento(5, "Departamento5");
        int objetoId = (int)await _unitOfWork.DepartamentoRepository.AdicionarAsync(departamento);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Departamento()
    {
        var novoNome = "DepartamentoUpdated";
        var departamento = await _unitOfWork.DepartamentoRepository.ObterPorIdAsync(4);

        departamento.Atualizar(novoNome);
        _unitOfWork.DepartamentoRepository.AtualizarAsync(departamento);
        await _unitOfWork.CommitAsync();

        departamento.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Departamento()
    {
        var id = 1;
        await _unitOfWork.DepartamentoRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var departamentoExcluido = await _unitOfWork.DepartamentoRepository.ObterPorIdAsync(id);
        departamentoExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.DepartamentoRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
