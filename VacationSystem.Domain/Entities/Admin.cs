using VacationSystem.Domain.Entities.Shared;

namespace VacationSystem.Domain.Entities;

public class Admin : Entity
{
    public Admin(string nome, string cargo, string levelAcesso)
    {
        this.Nome = nome;
        this.Cargo = cargo;
        this.LevelAcesso = levelAcesso;
    }

    private void Atualizar(string nome, string cargo, string levelAcesso)
    {;
        this.Nome = nome;
        this.Cargo = cargo;
        this.LevelAcesso = levelAcesso;
    }

    public string Nome { get; private set; }

    public string Cargo { get; private set; }

    public string LevelAcesso { get; private set; }
}
