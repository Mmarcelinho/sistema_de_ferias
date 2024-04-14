namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.AlterarSenha;

    public interface IAlterarSenhaAdminUseCase
    {
        Task Executar(RequisicaoAlterarSenhaJson requisicao);
    }
