using System.Text.Json.Serialization;
using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class PedidoFerias : Entity
{
    public PedidoFerias() {}

    [JsonConstructor]
     public PedidoFerias(int id, int funcionarioId, DateTime dataInicio, DateTime dataFim, int dias)
    {
        Id = id;
        DataPedido = DateTime.Now;
        ValidateDomain(funcionarioId, dataInicio, dataFim, dias);
    }

    public PedidoFerias(int funcionarioId, DateTime dataInicio, DateTime dataFim, int dias)
    {
        DataPedido = DateTime.Now;
        ValidateDomain(funcionarioId, dataInicio, dataFim, dias);
    }

    public void Atualizar(string status) => Status = status;
    
    public int FuncionarioId { get; private set; }

    public int? AdminId { get; private set; }

    public Funcionario Funcionario { get; private set; } = null!;

    public Admin Admin { get; private set; } = null!;

    public DateTime DataPedido { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public int Dias { get; private set; }

    public string Status { get; private set; } = "Pendente";

     private void ValidateDomain(int funcionarioId, DateTime dataInicio, DateTime dataFim, int dias)
    {
        DomainValidation.When(funcionarioId <= 0, "Obrigátorio");

        DomainValidation.When(dias <= 0, "Valor Inválido. Dias é obrigátorio");

        this.FuncionarioId = funcionarioId;
        this.DataInicio = dataInicio;
        this.DataFim = dataFim;
        this.Dias = dias;
    }

    public void Aprovado(int adminId)
    {
        if(Status != "Pendente")
        throw new InvalidOperationException("Apenas solicitações pendentes podem ser aprovadas.");

        Status = "Aprovado";
        AdminId = adminId;
    }

    public void Negado(int adminId)
    {
        if(Status != "Pendente")
        throw new InvalidOperationException("Apenas solicitações pendentes podem ser negadas.");

        Status = "Negado";
        AdminId = adminId;
    }
}
