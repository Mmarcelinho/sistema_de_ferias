namespace Utilitario.Testes.Repositorios.Departamento;

public class DepartamentoReadOnlyRepositorioBuilder
{
    private static DepartamentoReadOnlyRepositorioBuilder _instance;
    private readonly Mock<IDepartamentoReadOnlyRepositorio> _repositorio;

    private DepartamentoReadOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IDepartamentoReadOnlyRepositorio>();
        }
    }

    public static DepartamentoReadOnlyRepositorioBuilder Instancia()
    {
        _instance = new DepartamentoReadOnlyRepositorioBuilder();
        return _instance;
    }

    public DepartamentoReadOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        _repositorio.Setup(r => r.RecuperarPorId(departamento.Id)).ReturnsAsync(departamento);

        return this;
    }

    public IDepartamentoReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }    
}
