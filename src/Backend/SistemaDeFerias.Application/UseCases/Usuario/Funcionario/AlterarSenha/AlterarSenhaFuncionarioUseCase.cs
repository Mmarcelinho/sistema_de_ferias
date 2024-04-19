using SistemaDeFerias.Application.Servicos.UsuarioLogado;
using SistemaDeFerias.Application.UseCases.Usuario.AlterarSenha;
using SistemaDeFerias.Domain.Repositorios.Usuario;

namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.AlterarSenha;

public class AlterarSenhaFuncionarioUseCase : AlterarSenhaUsuarioUseCase<Domain.Entidades.Funcionario>, IAlterarSenhaFuncionarioUseCase
{
    public AlterarSenhaFuncionarioUseCase(IUsuarioUpdateOnlyRepositorio<Domain.Entidades.Funcionario> repositorio, IUsuarioLogado<Domain.Entidades.Funcionario> usuarioLogado, EncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho) : base(repositorio, usuarioLogado, encriptadorDeSenha, unidadeDeTrabalho)
    {
    }
}