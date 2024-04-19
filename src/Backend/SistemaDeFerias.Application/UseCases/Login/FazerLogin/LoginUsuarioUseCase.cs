namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin;

public class LoginUsuarioUseCase<TEntidade> : ILoginUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
{
    private readonly IUsuarioReadOnlyRepositorio<TEntidade> _usuarioReadOnlyRepositorio;

    private readonly EncriptadorDeSenha _encriptadorDeSenha;

    private readonly TokenController _tokenController;

    public LoginUsuarioUseCase(IUsuarioReadOnlyRepositorio<TEntidade> usuarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginUsuarioJson> Executar(RequisicaoLoginUsuarioJson requisicao)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);

        var usuario = await _usuarioReadOnlyRepositorio.RecuperarPorEmailSenha(requisicao.Email, senhaCriptografada);

        if (usuario is null)
            throw new LoginInvalidoException();

        return new RespostaLoginUsuarioJson(usuario.Nome,
            _tokenController.GerarToken(usuario.Email));
    }
}
