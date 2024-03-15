using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Data;

namespace VacationSystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly Context _context;
    private IFuncionarioRepository funcionarioRepository;

    private IDepartamentoRepository departamentoRepository;

    private IAdminRepository adminRepository;

    private IPedidoFeriasRepository pedidoFeriasRepository;

    public UnitOfWork(Context context) => _context = context;

    public IFuncionarioRepository FuncionarioRepository
    {
        get
        {
            return funcionarioRepository = funcionarioRepository ?? new FuncionarioRepository(_context);
        }
    }

    public IDepartamentoRepository DepartamentoRepository
    {
        get
        {
            return departamentoRepository = departamentoRepository ?? new DepartamentoRepository(_context);
        }
    }

    public IAdminRepository AdminRepository
    {
        get
        {
            return adminRepository = adminRepository ?? new AdminRepository(_context);
        }
    }

    public IPedidoFeriasRepository PedidoFeriasRepository
    {
        get
        {
            return pedidoFeriasRepository = pedidoFeriasRepository ?? new PedidoFeriasRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
