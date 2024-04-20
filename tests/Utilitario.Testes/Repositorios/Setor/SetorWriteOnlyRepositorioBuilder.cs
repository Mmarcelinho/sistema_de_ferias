namespace Utilitario.Testes.Domain.RepositorioSetor;

public class SetorWriteOnlyRepositorioBuilder
{
    private static SetorWriteOnlyRepositorioBuilder _instance;
    private readonly Mock<ISetorWriteOnlyRepositorio> _repositorio;

    private SetorWriteOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<ISetorWriteOnlyRepositorio>();
        }
    }

    public static SetorWriteOnlyRepositorioBuilder Instancia()
    {
        _instance = new SetorWriteOnlyRepositorioBuilder();
        return _instance;
    }

    public ISetorWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}