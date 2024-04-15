using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
using SistemaDeFerias.Comunicacao.Respostas.Admin;

namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;

    public interface ILoginAdminUseCase
    {
        Task<RespostaLoginAdminJson> Executar(RequisicaoLoginAdminJson requisicao);
    }
