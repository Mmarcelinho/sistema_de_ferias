using VacationSystem.Domain.Entities;

namespace VacationSystem.Domain.Interfaces.Services;

public interface IPedidoFeriasService
{
    PedidoFerias PedirFerias(Funcionario funcionario, DateTime dataInicio, int dias);

    void AprovarPedidoFerias(PedidoFerias pedidoFerias, Admin admin, bool aprovacao);
}
