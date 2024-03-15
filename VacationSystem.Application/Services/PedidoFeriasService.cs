using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Domain.Interfaces.Services;

namespace VacationSystem.Application.Services;

public class PedidoFeriasService : IPedidoFeriasService
{

    private readonly IUnitOfWork _unitOfWork;

    public PedidoFeriasService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    public void PedirFerias(Funcionario funcionario, DateTime dataInicio, int dias)
    {
        var pedirFerias = funcionario.CriarPedidoFerias(dataInicio,dias);
        _unitOfWork.PedidoFeriasRepository.AdicionarAsync(pedirFerias);
        _unitOfWork.CommitAsync();
    }

    public void AprovarPedidoFerias(PedidoFerias pedidoFerias, Admin admin, bool aprovacao)
    {
        if(aprovacao)
        pedidoFerias.Aprovado(admin.Id);

        else
        pedidoFerias.Negado(admin.Id);

        _unitOfWork.PedidoFeriasRepository.AtualizarAsync(pedidoFerias);
    }

}
