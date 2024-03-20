using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Domain.Interfaces.Services;

namespace VacationSystem.Application.Services;

public class PedidoFeriasService(IUnitOfWork unitOfWork) : IPedidoFeriasService
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public PedidoFerias PedirFerias(Funcionario funcionario, DateTime dataInicio, int dias)
    {
        var pedirFerias = funcionario.CriarPedidoFerias(dataInicio, dias);
        _unitOfWork.PedidoFeriasRepository.AdicionarAsync(pedirFerias);
        return pedirFerias;
    }

    public PedidoFerias AprovarPedidoFerias(PedidoFerias pedidoFerias, Admin admin, bool aprovacao)
    {
        if (aprovacao)
        {
            pedidoFerias.Aprovado(admin.Id);
            AtualizarUltimasFerias(pedidoFerias.FuncionarioId, pedidoFerias.DataInicio);
        }
            
        else
            pedidoFerias.Negado(admin.Id);

        _unitOfWork.PedidoFeriasRepository.AtualizarAsync(pedidoFerias);

        return pedidoFerias;
    }

    private async void AtualizarUltimasFerias(int funcionarioId, DateTime dataInicio)
    {
        var funcionario = await _unitOfWork.FuncionarioRepository.ObterPorIdAsync(funcionarioId);
        funcionario.AtualizarUltimaFerias(dataInicio);
        _unitOfWork.FuncionarioRepository.AtualizarAsync(funcionario);
    }

}
