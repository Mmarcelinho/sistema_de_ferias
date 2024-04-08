using System.Text.Json.Serialization;
using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Departamento : Entity
{
    public Departamento() { }

    public Departamento(string nome)
    {
        ValidateDomain(nome);
    }

    [JsonConstructor]
    public Departamento(int id, string nome)
    {
        Id = id;
        ValidateDomain(nome);
    }

    public void Atualizar(string nome)
    {
        this.Nome = nome;
    }
    public string Nome { get; private set; }

    public List<Funcionario> Funcionarios { get; private set; } = null!;

    private void ValidateDomain(string nome)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        Nome = nome;
    }
}

    