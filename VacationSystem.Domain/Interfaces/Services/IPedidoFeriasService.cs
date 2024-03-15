using VacationSystem.Domain.Entities;

namespace VacationSystem.Domain.Interfaces.Services;

    public interface IPedidoFeriasService
    {
        void PedirFerias(Funcionario funcionario, DateTime DataInicio, int Dias);

        void AprovarPedidoFerias(PedidoFerias pedidoFerias, Admin admin, bool aprovacao);
    }
