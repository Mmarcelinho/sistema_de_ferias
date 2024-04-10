namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio;

public class SetorRepositorio : ISetorReadOnlyRepositorio, ISetorWriteOnlyRepositorio, ISetorUpdateOnlyRepositorio
{
    private readonly SistemaDeFeriasContext _contexto;

    public SetorRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

    async Task<Setor> ISetorReadOnlyRepositorio.RecuperarPorId(long setorId)
    {
        return await _contexto.Setores.AsNoTracking()
        .FirstOrDefaultAsync(d => d.Id == setorId);
    }

    async Task<Setor> ISetorUpdateOnlyRepositorio.RecuperarPorId(long setorId)
    {
        return await _contexto.Setores.AsNoTracking()
        .FirstOrDefaultAsync(d => d.Id == setorId);
    }

    public async Task<Setor> RecuperarPorNome(string nome)
    {
        return await _contexto.Setores.AsNoTracking()
        .FirstOrDefaultAsync(d => d.Nome.Equals(nome));
    }

    public async Task Registrar(Setor setor) =>
    await _contexto.Setores.AddAsync(setor);

    public void Atualizar(Setor setor) =>
    _contexto.Setores.Update(setor);

    public async Task Deletar(long setorId)
    {
        var setor = await _contexto.Setores
        .FirstOrDefaultAsync(d => d.Id == setorId);

        _contexto.Setores.Remove(setor);
    }
}
