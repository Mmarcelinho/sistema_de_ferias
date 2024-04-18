namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class AdminRepositorio : UsuarioRepositorio<Admin>
{
    public AdminRepositorio(SistemaDeFeriasContext contexto) : base(contexto)
    { }
}
    
