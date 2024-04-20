namespace Utilitario.Testes.Repositorios.Funcionario;

public class FuncionarioUpdateOnlyRepositorioBuilder
{
    private static FuncionarioUpdateOnlyRepositorioBuilder _instance;
    private readonly Mock<IFuncionarioUpdateOnlyRepositorio> _repositorio;

    private FuncionarioUpdateOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IFuncionarioUpdateOnlyRepositorio>();
        }
    }

    public static FuncionarioUpdateOnlyRepositorioBuilder Instancia()
    {
        _instance = new FuncionarioUpdateOnlyRepositorioBuilder();
        return _instance;
    }

    public FuncionarioUpdateOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Funcionario funcionario)
    {
        _repositorio.Setup(c => c.RecuperarPorId(funcionario.Id)).ReturnsAsync(funcionario);

        return this;
    }

    public IFuncionarioUpdateOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}
