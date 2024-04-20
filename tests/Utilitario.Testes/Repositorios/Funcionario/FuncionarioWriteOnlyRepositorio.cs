namespace Utilitario.Testes.Domain.Repositorios.Funcionario;

public class FuncionarioWriteOnlyRepositorioBuilder
{
    private static FuncionarioWriteOnlyRepositorioBuilder _instance;
    private readonly Mock<IFuncionarioWriteOnlyRepositorio> _repositorio;

    private FuncionarioWriteOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IFuncionarioWriteOnlyRepositorio>();
        }
    }

    public static FuncionarioWriteOnlyRepositorioBuilder Instancia()
    {
        _instance = new FuncionarioWriteOnlyRepositorioBuilder();
        return _instance;
    }

    public IFuncionarioWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}