using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;

    public interface IRegistrarFuncionarioUseCase
    {
        Task<RespostaFuncionarioRegistradoJson> Executar(RequisicaoRegistrarFuncionarioJson requisicao);
    }
