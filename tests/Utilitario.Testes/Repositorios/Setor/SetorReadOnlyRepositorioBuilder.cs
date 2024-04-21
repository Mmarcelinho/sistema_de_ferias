using Moq;

namespace Utilitario.Testes.Repositorios.Setor;

public class SetorReadOnlyRepositorioBuilder
{
    private static SetorReadOnlyRepositorioBuilder _instance;
    private readonly Mock<ISetorReadOnlyRepositorio> _repositorio;

    private SetorReadOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<ISetorReadOnlyRepositorio>();
        }
    }

    public static SetorReadOnlyRepositorioBuilder Instancia()
    {
        _instance = new SetorReadOnlyRepositorioBuilder();
        return _instance;
    }

    public SetorReadOnlyRepositorioBuilder RecuperarTodos(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        if(setor is not null)
        _repositorio.Setup(r => r.RecuperarTodos()).ReturnsAsync(new List<SistemaDeFerias.Domain.Entidades.Setor> { setor });

        return this;
    }
    public SetorReadOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        _repositorio.Setup(r => r.RecuperarPorId(setor.Id)).ReturnsAsync(setor);

        return this;
    }

    public SetorReadOnlyRepositorioBuilder RecuperarPorNome(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        _repositorio.Setup(r => r.RecuperarPorNome(setor.Nome)).ReturnsAsync(setor);

        return this;
    }

    public ISetorReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }    
}
