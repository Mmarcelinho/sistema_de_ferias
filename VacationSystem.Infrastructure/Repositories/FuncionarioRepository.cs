using Microsoft.EntityFrameworkCore;
using VacationSystem.Domain.Entities;
using VacationSystem.Domain.Interfaces.Repositories;
using VacationSystem.Infrastructure.Data;
using VacationSystem.Infrastructure.Repositories.Shared;

namespace VacationSystem.Infrastructure.Repositories;

public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(Context context) : base(context) { }
    public override async Task<IEnumerable<Funcionario>> ObterTodosAsync()
    {
        var listaObjeto = await Context.Funcionarios
        .Include(x => x.Departamento)
        .ToListAsync();
        return listaObjeto ?? Enumerable.Empty<Funcionario>();
    }

    public override async Task<Funcionario?> ObterPorIdAsync(int id)
    {
        var funcionario = await Context.Funcionarios
       .Include(x => x.Departamento)
       .Where(x => x.Id == id).FirstOrDefaultAsync();

       return funcionario;
    }

}