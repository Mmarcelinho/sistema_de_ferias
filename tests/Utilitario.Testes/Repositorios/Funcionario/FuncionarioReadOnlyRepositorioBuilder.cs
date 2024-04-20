namespace Utilitario.Testes.Repositorios.Funcionario;

public class FuncionarioReadOnlyRepositorioBuilder
{
    private static FuncionarioReadOnlyRepositorioBuilder _instance;

    private readonly Mock<IFuncionarioReadOnlyRepositorio> _repositorio;

    private FuncionarioReadOnlyRepositorioBuilder()
    {
        if (_repositorio is null)
        {
            _repositorio = new Mock<IFuncionarioReadOnlyRepositorio>();
        }
    }

    public static FuncionarioReadOnlyRepositorioBuilder Instancia()
    {
        _instance = new FuncionarioReadOnlyRepositorioBuilder();
        return _instance;
    }

    public FuncionarioReadOnlyRepositorioBuilder ExisteUsuarioComEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
            _repositorio.Setup(i => i.ExisteUsuarioComEmail(email)).ReturnsAsync(true);

        return this;
    }

    public FuncionarioReadOnlyRepositorioBuilder RecuperarPorEmailSenha(SistemaDeFerias.Domain.Entidades.Funcionario funcionario)
    {
        _repositorio.Setup(i => i.RecuperarPorEmailSenha(funcionario.Email, funcionario.Senha)).ReturnsAsync(funcionario);

        return this;
    }

    public IFuncionarioReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }

}
