namespace SistemaDeFerias.Domain.Repositorios.Setor;

    public interface ISetorUpdateOnlyRepositorio
    {
       void Atualizar(Entidades.Setor setor);

        Task<Entidades.Setor> RecuperarPorId(long setorId); 
    }
