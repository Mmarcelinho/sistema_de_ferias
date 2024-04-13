namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class FuncionarioRepositorio : IFuncionarioReadOnlyRepositorio, IFuncionarioWriteOnlyRepositorio, IFuncionarioUpdateOnlyRepositorio
{
    private readonly SistemaDeFeriasContext _contexto;

    public FuncionarioRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

    public async Task Adicionar(Funcionario funcionario)
    =>
        await _contexto.Funcionarios.AddAsync(funcionario);


    public async Task<bool> ExisteFuncionarioComEmail(string email) =>
    await _contexto.Funcionarios.AnyAsync(c => c.Email.Equals(email));


    public async Task<Funcionario> RecuperarPorEmail(string email)
    =>
        await _contexto.Funcionarios.AsNoTracking()
        .FirstOrDefaultAsync(c => c.Email.Equals(email));


    public async Task<Funcionario> RecuperarPorEmailSenha(string email, string senha)
    =>
        await _contexto.Funcionarios.AsNoTracking()
        .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));


    public async Task<Funcionario> RecuperarPorId(long id)
    =>
        await _contexto.Funcionarios.FirstOrDefaultAsync(c => c.Id == id);
    

    public void Atualizar(Funcionario funcionario) =>
        _contexto.Funcionarios.Update(funcionario);
}
