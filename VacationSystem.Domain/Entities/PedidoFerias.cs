using VacationSystem.Domain.Entities.Shared;
using VacationSystem.Domain.Validation;

namespace VacationSystem.Domain.Entities;

public class PedidoFerias : Entity
{
    public PedidoFerias() {}
    public PedidoFerias(Funcionario funcionario, int funcionarioId, DateTime dataInicio, DateTime dataFim, int dias)
    {
        Funcionario = funcionario;
        DataPedido = DateTime.Now;
        Status = "Pendente";
        ValidateDomain(funcionarioId, dataInicio, dataFim, dias);

    }
    public int FuncionarioId { get; private set; }

    public int? AdminId { get; private set; }

    public Funcionario Funcionario { get; private set; } = null!;

    public Admin Admin { get; private set; } = null!;

    public DateTime DataPedido { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public int Dias { get; private set; }

    public string Status { get; private set; }

     private void ValidateDomain(int funcionarioId, DateTime dataInicio, DateTime dataFim, int dias)
    {
        DomainValidation.When(funcionarioId <= 0, "Obrigátorio");

        DomainValidation.When(dias <= 0, "Valor Inválido. Dias é obrigátorio");

        this.FuncionarioId = funcionarioId;
        this.DataInicio = dataInicio;
        this.DataFim = dataFim;
        this.Dias = dias;
    }
}
