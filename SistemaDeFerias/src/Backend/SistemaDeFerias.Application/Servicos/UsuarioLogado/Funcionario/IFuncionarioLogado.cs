namespace SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;

    public interface IFuncionarioLogado
    {
        Task<Domain.Entidades.Funcionario> RecuperarFuncionario();
    }
