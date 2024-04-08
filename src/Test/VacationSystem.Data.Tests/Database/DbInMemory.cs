using VacationSystem.Domain.Entities;
using VacationSystem.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace VacationSystem.Data.Tests.Database;

public class DbInMemory
{
    private Context _dataContext;

    private readonly SqliteConnection _connection;

    public DbInMemory()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<Context>()
        .UseSqlite(_connection)
        .EnableSensitiveDataLogging()
        .Options;

        _dataContext = new Context(options);
        InsertFakeData();
    }

    public Context GetContext() => _dataContext;

    public void Cleanup() => _connection.Close();

    private void InsertFakeData()
    {
        if (_dataContext.Database.EnsureCreated())
        {
            var ids = new[] { 1, 2, 3, 4 };

            ids.ToList().ForEach(id =>
            {
                FuncionarioFakeData(id);
                DepartamentoFakeData(id);
                AdminFakeData(id);
                PedidoFerias(id);
            });
            _dataContext.SaveChanges();
        }
    }

    private void FuncionarioFakeData(int id) =>
    _dataContext.Funcionarios.AddAsync(new Funcionario(id, $"Funcionário{id}", $"Funcão{id}", $"Setor{id}", DateTime.Now, id));

    private void DepartamentoFakeData(int id) =>
    _dataContext.Departamentos.AddAsync(new Departamento(id, $"Departamento{id}"));

    private void AdminFakeData(int id) =>
    _dataContext.Admins.AddAsync(new Admin(id, $"Admin{id}", $"Cargo{id}", $"LevelAcesso{id}"));

    private void PedidoFerias(int id)
    {
    _dataContext.PedidosFerias.AddAsync(new PedidoFerias(id, id, DateTime.Now, DateTime.Now, 10 * id));
    }
}

