namespace VacationSystem.Domain.Interfaces.Repositories;

    public interface IUnitOfWork
    {
        IFuncionarioRepository FuncionarioRepository { get; }

        IDepartamentoRepository DepartamentoRepository { get; }

        IAdminRepository AdminRepository { get; }

        IPedidoFeriasRepository PedidoFeriasRepository { get; }

        Task CommitAsync();
    }
