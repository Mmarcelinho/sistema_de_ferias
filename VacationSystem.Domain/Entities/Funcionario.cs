using System.Text.Json.Serialization;
using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Funcionario : Entity
{
    public Funcionario(string nome, string funcao, string setor, DateTime dataInicio, int departamentoId)
    {
        ValidateDomain(nome, funcao, setor, dataInicio, departamentoId);
    }

    [JsonConstructor]
    public Funcionario(int id, string nome, string funcao, string setor, DateTime dataInicio, int departamentoId)
    {
        Id = id;
        ValidateDomain(nome, funcao, setor, dataInicio, departamentoId);
    }


    public void Atualizar(string nome, string funcao, string setor, int departamentoId)
    {
        Nome = nome;
        Funcao = funcao;
        Setor = setor;
        DepartamentoId = departamentoId;
    }

    public void AtualizarUltimaFerias(DateTime dataFimUltimaFerias)
    {
        DataFimUltimaFerias = dataFimUltimaFerias;
    }

    public string Nome { get; private set; }

    public string Funcao { get; private set; }

    public string Setor { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime? DataFimUltimaFerias { get; private set; }

    public int DepartamentoId { get; private set; }

    public Departamento Departamento { get; private set; } = null!;

    public List<PedidoFerias> PedidosFerias { get; private set; } = null!;

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

    public bool ElegivelParaFerias()
    {
        var DiasTrabalhados = DateTime.Today.Subtract(DataInicio).TotalDays;
        if (DataFimUltimaFerias == null && DiasTrabalhados >= 365)
            return true;

        else
            return VerificarUltimaFerias();
    }

    public bool VerificarUltimaFerias()
    {
        if (DataFimUltimaFerias == null)
            return false;

        var DiasTrabalhadosPosFerias = DateTime.Today.Subtract(DataFimUltimaFerias.Value).TotalDays;
        if (!(DiasTrabalhadosPosFerias >= 365))
            return false;

        return true;
    }

    public PedidoFerias CriarPedidoFerias(DateTime dataInicio, int dias)
    {
        if (!ElegivelParaFerias())
            throw new InvalidOperationException("Funcionário não é elegível para férias.");

        PedidosFerias = new List<PedidoFerias>();

        var pedidoFerias = new PedidoFerias(this, Id, dataInicio, dataInicio.AddDays(dias), dias);

        PedidosFerias.Add(pedidoFerias);

        return pedidoFerias;
    }

}


