using SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;
using SistemaDeFerias.Comunicacao.Respostas.Funcionario;

namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Funcionario;

    public interface ILoginFuncionarioUseCase
    {
        Task<RespostaLoginFuncionarioJson> Executar(RequisicaoLoginFuncionarioJson requisicao);
    }
