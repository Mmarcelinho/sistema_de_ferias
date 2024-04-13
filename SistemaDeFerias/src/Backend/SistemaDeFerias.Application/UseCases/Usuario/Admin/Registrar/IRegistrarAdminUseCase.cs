using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
using SistemaDeFerias.Comunicacao.Respostas.Admin;

namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;

    public interface IRegistrarAdminUseCase
    {
        Task<RespostaAdminRegistradoJson> Executar(RequisicaoRegistrarAdminJson requisicao);
    }
