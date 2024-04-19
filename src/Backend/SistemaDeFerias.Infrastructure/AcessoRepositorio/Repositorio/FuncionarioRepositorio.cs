namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class FuncionarioRepositorio : UsuarioRepositorio<Funcionario>, IFuncionarioReadOnlyRepositorio, IFuncionarioWriteOnlyRepositorio, IFuncionarioUpdateOnlyRepositorio
{
    public FuncionarioRepositorio(SistemaDeFeriasContext contexto) : base(contexto)
    { }
}
