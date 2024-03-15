using VacationSystem.Domain.Entities.Shared;

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

    public Departamento Departamento { get; private set; }

    public List<PedidoFerias> PedidoFerias { get; private set; }
}


