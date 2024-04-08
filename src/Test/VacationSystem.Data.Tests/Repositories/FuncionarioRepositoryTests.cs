namespace VacationSystem.Data.Tests.Repositories;

public class FornecedorRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public FornecedorRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var funcionarios = await _unitOfWork.FuncionarioRepository.ObterTodosAsync();
        funcionarios.Should().HaveCount(4);
    }

    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Funcionario()
    {
        var funcionario = new Funcionario(5, "Funcionário5", "Funcão5", "Setor5", DateTime.Now, 5);
        int objetoId = (int)await _unitOfWork.FuncionarioRepository.AdicionarAsync(funcionario);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);     
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Funcionario()
    {
        var novoNome = "FuncionarioUpdated";
        var funcionario = await _unitOfWork.FuncionarioRepository.ObterPorIdAsync(4);

        funcionario.Atualizar(novoNome,funcionario.Funcao,funcionario.Setor,funcionario.DepartamentoId);
        _unitOfWork.FuncionarioRepository.AtualizarAsync(funcionario);
        await _unitOfWork.CommitAsync();

        funcionario.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Funcionario()
    {
        var id = 1;
        await _unitOfWork.FuncionarioRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var funcionarioExcluido = await _unitOfWork.FuncionarioRepository.ObterPorIdAsync(id);
        funcionarioExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.FuncionarioRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
