namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class AdminRepositorio : UsuarioRepositorio<Admin>, IAdminReadOnlyRepositorio, IAdminWriteOnlyRepositorio, IAdminUpdateOnlyRepositorio
{
    public AdminRepositorio(SistemaDeFeriasContext contexto) : base(contexto)
    { }
}
    
