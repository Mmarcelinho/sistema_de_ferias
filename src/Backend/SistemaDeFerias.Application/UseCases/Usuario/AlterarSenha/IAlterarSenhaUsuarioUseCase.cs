namespace SistemaDeFerias.Application.UseCases.Usuario.AlterarSenha;

    public interface IAlterarSenhaUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
    {
        Task Executar(RequisicaoAlterarSenhaJson requisicao);
    }
