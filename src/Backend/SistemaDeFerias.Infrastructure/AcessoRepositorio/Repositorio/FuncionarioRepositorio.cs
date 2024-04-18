namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class FuncionarioRepositorio : UsuarioRepositorio<Funcionario>
{
    public FuncionarioRepositorio(SistemaDeFeriasContext contexto) : base(contexto)
    { }
}
