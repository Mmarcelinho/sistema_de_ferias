using SistemaDeFerias.Comunicacao.Requisicoes.Admin;
using SistemaDeFerias.Comunicacao.Respostas.Admin;

namespace SistemaDeFerias.Application.UseCases.Login.FazerLogin.Admin;

public class LoginAdminUseCase : ILoginAdminUseCase
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;

    private readonly EncriptadorDeSenha _encriptadorDeSenha;

    private readonly TokenController _tokenController;

    public LoginAdminUseCase(IAdminReadOnlyRepositorio adminReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginAdminJson> Executar(RequisicaoLoginAdminJson requisicao)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);

        var admin = await _adminReadOnlyRepositorio.RecuperarPorEmailSenha(requisicao.Email, senhaCriptografada);

        if (admin is null)
            throw new LoginInvalidoException();

        return new RespostaLoginAdminJson(admin.Nome,
            _tokenController.GerarToken(admin.Email));
    }
}
