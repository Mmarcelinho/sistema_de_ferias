namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.AlterarSenha;

    public interface IAlterarSenhaFuncionarioUseCase
    {
        Task Executar(RequisicaoAlterarSenhaJson requisicao);
    }
