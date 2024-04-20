namespace Utilitario.Testes.Repositorios.Setor;

public class SetorUpdateOnlyRepositorioBuilder
{
    private static SetorUpdateOnlyRepositorioBuilder _instance;
    private readonly Mock<ISetorUpdateOnlyRepositorio> _repositorio;

    private SetorUpdateOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<ISetorUpdateOnlyRepositorio>();
        }
    }

    public static SetorUpdateOnlyRepositorioBuilder Instancia()
    {
        _instance = new SetorUpdateOnlyRepositorioBuilder();
        return _instance;
    }

    public SetorUpdateOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Setor setor)
    {
        _repositorio.Setup(r => r.RecuperarPorId(setor.Id)).ReturnsAsync(setor);
            
        return this;
    }

    public ISetorUpdateOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
