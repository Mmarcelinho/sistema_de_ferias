using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Funcionario : Entity
{
    public Funcionario(string nome, string funcao, string setor, DateTime dataInicio, int departamentoId, Departamento departamento)
    {
        this.Nome = nome;
        this.Funcao = funcao;
        this.Setor = setor;
        this.DataInicio = dataInicio;
        this.DepartamentoId = departamentoId;
        this.Departamento = departamento;
    }

    public string Nome { get; private set; }

    public string Funcao { get; private set; }

    public string Setor { get; private set; }

    public DateTime DataInicio { get; private set; }

    public int DepartamentoId { get; private set; }

    public Departamento Departamento { get; private set; } = null!;

    public List<PedidoFerias> PedidoFerias { get; private set; } = null!;

    private void ValidateDomain(string nome, string funcao, string setor, DateTime dataInicio, int departamentoId)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        DomainValidation.When(string.IsNullOrEmpty(funcao), "Função inválido. Função é obrigátorio");

        DomainValidation.When(string.IsNullOrEmpty(setor), "Setor inválido. Setor é obrigátorio");

        Nome = nome;
        Funcao = funcao;
        Setor = setor;
        DepartamentoId = departamentoId;
        DataInicio = dataInicio;
    }

    
}


