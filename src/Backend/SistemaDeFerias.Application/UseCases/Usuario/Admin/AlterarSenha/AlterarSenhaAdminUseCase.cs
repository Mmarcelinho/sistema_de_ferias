namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.AlterarSenha;

public class AlterarSenhaAdminUseCase : AlterarSenhaUsuarioUseCase<Domain.Entidades.Admin>, IAlterarSenhaAdminUseCase
{
    public AlterarSenhaAdminUseCase(
        IUsuarioUpdateOnlyRepositorio<Domain.Entidades.Admin> repositorio, 
        IUsuarioLogado<Domain.Entidades.Admin> usuarioLogado, 
        EncriptadorDeSenha encriptadorDeSenha, 
        IUnidadeDeTrabalho unidadeDeTrabalho) : 
        base(repositorio, usuarioLogado, encriptadorDeSenha, unidadeDeTrabalho)
        { }
}