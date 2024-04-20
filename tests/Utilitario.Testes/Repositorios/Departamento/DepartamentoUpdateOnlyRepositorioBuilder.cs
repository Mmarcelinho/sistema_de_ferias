namespace Utilitario.Testes.Repositorios.Departamento;

public class DepartamentoUpdateOnlyRepositorioBuilder
{
    private static DepartamentoUpdateOnlyRepositorioBuilder _instance;
    private readonly Mock<IDepartamentoUpdateOnlyRepositorio> _repositorio;

    private DepartamentoUpdateOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IDepartamentoUpdateOnlyRepositorio>();
        }
    }

    public static DepartamentoUpdateOnlyRepositorioBuilder Instancia()
    {
        _instance = new DepartamentoUpdateOnlyRepositorioBuilder();
        return _instance;
    }

    public DepartamentoUpdateOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        _repositorio.Setup(r => r.RecuperarPorId(departamento.Id)).ReturnsAsync(departamento);
            
        return this;
    }

    public IDepartamentoUpdateOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
