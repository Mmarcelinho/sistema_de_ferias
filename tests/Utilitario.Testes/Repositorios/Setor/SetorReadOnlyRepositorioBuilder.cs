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

    public SetorReadOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        _repositorio.Setup(r => r.RecuperarPorId(setor.Id)).ReturnsAsync(setor);

        return this;
    }

    public ISetorReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }    
}
