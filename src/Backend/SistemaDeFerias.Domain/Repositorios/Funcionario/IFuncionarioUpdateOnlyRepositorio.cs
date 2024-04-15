namespace SistemaDeFerias.Domain.Repositorios.Funcionario;

    public interface IFuncionarioUpdateOnlyRepositorio
    {
      void Atualizar(Entidades.Funcionario funcionario);

        Task<Entidades.Funcionario> RecuperarPorId(long funcionarioId);  
    }
