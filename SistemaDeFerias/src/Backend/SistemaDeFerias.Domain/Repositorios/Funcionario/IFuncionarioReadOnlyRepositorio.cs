namespace SistemaDeFerias.Domain.Repositorios.Funcionario;

    public interface IFuncionarioReadOnlyRepositorio
    {
        Task<Entidades.Funcionario> RecuperarPorId(long funcionarioId);

        Task<Entidades.Funcionario> RecuperarPorEmailSenha(string email, string senha);

        Task<Entidades.Funcionario> RecuperarPorEmail(string email);
    }
