using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class Funcionario : Entity
{
    public Funcionario(string nome, string funcao, string setor, DateTime dataInicio, int departamentoId)
    {
        this.Nome = nome;
        this.Funcao = funcao;
        this.Setor = setor;
        this.DataInicio = dataInicio;
        this.DepartamentoId = departamentoId;
    }

     public void Atualizar(string nome, string funcao, string setor, int departamentoId)
    {
        this.Nome = nome;
        this.Funcao = funcao;
        this.Setor = setor;
        this.DepartamentoId = departamentoId;
    }

    public void AtualizarUltimaFerias(DateTime dataFimUltimaFerias)
    {
        this.DataFimUltimaFerias = dataFimUltimaFerias;
    }

    public string Nome { get; private set; }

    public string Funcao { get; private set; }

    public string Setor { get; private set; }

    public DateTime DataInicio { get; private set; }

     public DateTime? DataFimUltimaFerias { get; private set; }

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

    public bool ElegivelParaFerias()
    {
        return DataFimUltimaFerias == null || (DateTime.Today - DataFimUltimaFerias.Value).TotalDays >= 365;
    }

    public PedidoFerias CriarPedidoFerias(DateTime dataInicio, int dias)
    {
        if(!ElegivelParaFerias())
            throw new InvalidOperationException("Funcionário não é elegível para férias.");

        PedidoFerias = new List<PedidoFerias>();

        var FeriasRequest = new PedidoFerias(this, this.Id, dataInicio, dataInicio.AddDays(dias), dias);

        PedidoFerias.Add(FeriasRequest);
        
        return FeriasRequest;
    }
    
}


