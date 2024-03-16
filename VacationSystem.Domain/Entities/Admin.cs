using System.Text.Json.Serialization;
using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Admin : Entity
{
    public Admin() { }

    public Admin(string nome, string cargo, string levelAcesso)
    {
        ValidateDomain(nome, cargo, levelAcesso);
    }
    
    [JsonConstructor]
    public Admin(int id, string nome, string cargo, string levelAcesso)
    {
        Id = id;
        ValidateDomain(nome, cargo, levelAcesso);
    }

    public void Atualizar(string nome, string cargo, string levelAcesso)
    {;
         ValidateDomain(nome, cargo, levelAcesso);
    }

    public string Nome { get; private set; }

    public string Cargo { get; private set; }

    public string LevelAcesso { get; private set; }

    public List<PedidoFerias> PedidosFerias { get; private set; } = null!;

    private void ValidateDomain(string nome, string cargo, string levelAcesso)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        DomainValidation.When(string.IsNullOrEmpty(cargo), "Cargo inválido. Cargo é obrigátorio");

        DomainValidation.When(string.IsNullOrEmpty(levelAcesso), "Acesso inválido. Acesso é obrigátorio");

        Nome = nome;
        Cargo = cargo;
        LevelAcesso = levelAcesso;
    }
}
