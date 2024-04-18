using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Infrastructure.AcessoRepositorio.Repositorio
{
    public class UsuarioRepositorio<TEntidade> : IUsuarioReadOnlyRepositorio<TEntidade>, IUsuarioWriteOnlyRepositorio<TEntidade>, IUsuarioUpdateOnlyRepositorio<TEntidade> where TEntidade : Usuario
    {
        private readonly SistemaDeFeriasContext _contexto;

        public UsuarioRepositorio(SistemaDeFeriasContext contexto) => _contexto = contexto;

        async Task IUsuarioWriteOnlyRepositorio<TEntidade>.Adicionar(TEntidade entidade)
        =>
        await _contexto.Set<TEntidade>().AddAsync(entidade);
        
        async Task<bool> IUsuarioReadOnlyRepositorio<TEntidade>.ExisteUsuarioComEmail(string email)
        =>
        await _contexto.Set<TEntidade>().AnyAsync(c => c.Email.Equals(email));

        async Task<TEntidade> IUsuarioReadOnlyRepositorio<TEntidade>.RecuperarPorEmail(string email)
        =>
        await _contexto.Set<TEntidade>().AsNoTracking()
        .FirstOrDefaultAsync(c => c.Email.Equals(email));

        async Task<TEntidade> IUsuarioReadOnlyRepositorio<TEntidade>.RecuperarPorEmailSenha(string email, string senha)
        =>
        await _contexto.Set<TEntidade>().AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));

        async Task<TEntidade> IUsuarioReadOnlyRepositorio<TEntidade>.RecuperarPorId(long id)
        =>
        await _contexto.Set<TEntidade>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        

        void IUsuarioUpdateOnlyRepositorio<TEntidade>.Atualizar(TEntidade entidade)
        =>
        _contexto.Set<TEntidade>().Update(entidade);

        async Task<TEntidade> IUsuarioUpdateOnlyRepositorio<TEntidade>.RecuperarPorId(long id)
        =>
        await _contexto.Set<TEntidade>().FirstOrDefaultAsync(c => c.Id == id);
    }
}