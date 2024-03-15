using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Departamento : Entity
{
    public Departamento(string nome)
    {
        ValidateDomain(nome);
    }

    private void Atualizar(string nome)
    {
        this.Nome = nome;
    }
    public string Nome { get; private set; }

    public List<Funcionario> Funcionarios { get; private set; }

    private void ValidateDomain(string nome)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        Nome = nome;
    }
}

    