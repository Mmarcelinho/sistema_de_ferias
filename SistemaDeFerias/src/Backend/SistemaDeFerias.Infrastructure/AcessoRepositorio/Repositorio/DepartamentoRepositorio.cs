
namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class DepartamentoRepositorio : IDepartamentoReadOnlyRepositorio, IDepartamentoWriteOnlyRepositorio, IDepartamentoUpdateOnlyRepositorio
{
    private readonly SistemaDeFeriasContext _contexto;

    public DepartamentoRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

    async Task<Departamento> IDepartamentoReadOnlyRepositorio.RecuperarPorId(long departamentoId)
    =>
        await _contexto.Departamentos
        .Include(d => d.Setor)
        .FirstOrDefaultAsync(d => d.Id == departamentoId);
    

    async Task<Departamento> IDepartamentoUpdateOnlyRepositorio.RecuperarPorId(long departamentoId)
    =>
        await _contexto.Departamentos
        .Include(d => d.Setor)
        .FirstOrDefaultAsync(d => d.Id == departamentoId);
    


    public async Task<Departamento> RecuperarPorNome(string nome)
    =>
        await _contexto.Departamentos.AsNoTracking()
        .Include(d => d.Setor)
        .FirstOrDefaultAsync(d => d.Nome.Equals(nome));
    

    public async Task Registrar(Departamento departamento) =>
    await _contexto.Departamentos.AddAsync(departamento);

    public void Atualizar(Departamento departamento) =>
    _contexto.Departamentos.Update(departamento);

    public async Task Deletar(long departamentoId)
    {
        var departamento = await _contexto.Departamentos
        .Include(d => d.Setor)
        .FirstOrDefaultAsync(d => d.Id == departamentoId);

        _contexto.Departamentos.Remove(departamento);
    }
}
