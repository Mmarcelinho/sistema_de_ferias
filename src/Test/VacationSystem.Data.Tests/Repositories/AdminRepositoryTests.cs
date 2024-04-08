namespace VacationSystem.Data.Tests.Repositories;

public class AdminRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public AdminRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var admins = await _unitOfWork.AdminRepository.ObterTodosAsync();
        admins.Should().HaveCount(4);
    }

    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Admin()
    {
        var admin = new Admin(5, "Admin5", "Cargo5", "LevelAcesso5");
        int objetoId = (int)await _unitOfWork.AdminRepository.AdicionarAsync(admin);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Admin()
    {
        var novoNome = "AdminUpdated";
        var admin = await _unitOfWork.AdminRepository.ObterPorIdAsync(4);

        admin.Atualizar(novoNome, admin.Cargo, admin.LevelAcesso);
        _unitOfWork.AdminRepository.AtualizarAsync(admin);
        await _unitOfWork.CommitAsync();

        admin.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Admin()
    {
        var id = 1;
        await _unitOfWork.AdminRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var adminExcluido = await _unitOfWork.AdminRepository.ObterPorIdAsync(id);
        adminExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.AdminRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
