namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.Registrar;

    public interface IRegistrarAdminUseCase
    {
        Task<RespostaAdminRegistradoJson> Executar(RequisicaoRegistrarAdminJson requisicao);
    }
