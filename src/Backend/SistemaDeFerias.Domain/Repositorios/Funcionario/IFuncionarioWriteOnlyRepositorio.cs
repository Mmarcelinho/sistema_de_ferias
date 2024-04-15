namespace SistemaDeFerias.Domain.Repositorios.Funcionario;

    public interface IFuncionarioWriteOnlyRepositorio
    {
      Task Adicionar(Entidades.Funcionario funcionario);
    }
