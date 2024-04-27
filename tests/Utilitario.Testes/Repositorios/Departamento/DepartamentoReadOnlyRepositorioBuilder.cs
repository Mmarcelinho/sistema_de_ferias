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

    public DepartamentoReadOnlyRepositorioBuilder RecuperarTodos(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        if(departamento is not null)
        _repositorio.Setup(r => r.RecuperarTodos()).ReturnsAsync(new List<SistemaDeFerias.Domain.Entidades.Departamento> { departamento });

        return this;
    }

    public DepartamentoReadOnlyRepositorioBuilder RecuperarPorId(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        _repositorio.Setup(r => r.RecuperarPorId(departamento.Id)).ReturnsAsync(departamento);

        return this;
    }

    public DepartamentoReadOnlyRepositorioBuilder RecuperarPorNome(SistemaDeFerias.Domain.Entidades.Departamento departamento)
    {
        _repositorio.Setup(r => r.RecuperarPorNome(departamento.Nome)).ReturnsAsync(departamento);

        return this;
    }

    public IDepartamentoReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }    
}
