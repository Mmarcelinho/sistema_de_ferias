using VacationSystem.Domain.Entities.Shared;

namespace VacationSystem.Domain.Entities;

public class Departamento : Entity
{
    public Departamento(string nome)
    {
        this.Nome = nome;
    }

    private void Atualizar(string nome)
    {
        this.Nome = nome;
    }
    public string Nome { get; private set; }

    public List<Funcionario> Funcionarios { get; private set; }
}
