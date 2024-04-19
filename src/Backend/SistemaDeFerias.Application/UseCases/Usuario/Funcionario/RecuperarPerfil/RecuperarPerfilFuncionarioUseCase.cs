using SistemaDeFerias.Application.UseCases.Usuario.RecuperarPerfil;

namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.RecuperarPerfil;

public class RecuperarPerfilFuncionarioUseCase : RecuperarPerfilUsuarioUseCase<Domain.Entidades.Funcionario>, IRecuperarPerfilFuncionarioUseCase
{
    public RecuperarPerfilFuncionarioUseCase(IMapper mapper, IUsuarioLogado<Domain.Entidades.Funcionario> usuarioLogado) : base(mapper, usuarioLogado)
    { }
}
