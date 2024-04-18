namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class AdminRepositorio : IAdminReadOnlyRepositorio, IAdminWriteOnlyRepositorio, IAdminUpdateOnlyRepositorio
{
    private readonly SistemaDeFeriasContext _contexto;

    public AdminRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

    public async Task Adicionar(Admin admin)
    =>
        await _contexto.Admins.AddAsync(admin);
    

    public async Task<bool> ExisteAdminComEmail(string email)
    =>
        await _contexto.Admins.AnyAsync(c => c.Email.Equals(email));
    

    public async Task<Admin> RecuperarPorEmail(string email)
    =>
        await _contexto.Admins.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email));
    

    public async Task<Admin> RecuperarPorEmailSenha(string email, string senha)
    =>
        await _contexto.Admins.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));
    

    public async Task<Admin> RecuperarPorId(long adminId)
    =>
        await _contexto.Admins.FirstOrDefaultAsync(c => c.Id == adminId);
    

    public void Atualizar(Admin admin) =>
        _contexto.Admins.Update(admin);
    
}
    
