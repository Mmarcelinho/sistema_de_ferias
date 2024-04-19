namespace SistemaDeFerias.Application.UseCases.Usuario.AlterarSenha;

public class AlterarSenhaUsuarioUseCase<TEntidade> : IAlterarSenhaUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
{
    private readonly IUsuarioLogado<TEntidade> _usuarioLogado;
    private readonly IUsuarioUpdateOnlyRepositorio<TEntidade> _repositorio;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AlterarSenhaUsuarioUseCase(IUsuarioUpdateOnlyRepositorio<TEntidade> repositorio, IUsuarioLogado<TEntidade> usuarioLogado, EncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
        _encriptadorDeSenha = encriptadorDeSenha;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Executar(RequisicaoAlterarSenhaJson requisicao)
    {
        var usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        var usuario = await _repositorio.RecuperarPorId(usuarioLogado.Id);

        Validar(requisicao, usuario);

        usuario.Senha = _encriptadorDeSenha.Criptografar(requisicao.NovaSenha);

        _repositorio.Atualizar(usuario);

        await _unidadeDeTrabalho.Commit();
    }

    private void Validar(RequisicaoAlterarSenhaJson requisicao, Domain.Entidades.Usuario usuario)
    {
        var validator = new AlterarSenhaValidator();
        var resultado = validator.Validate(requisicao);

        var senhaAtualCriptografada = _encriptadorDeSenha.Criptografar(requisicao.SenhaAtual);

        if (!usuario.Senha.Equals(senhaAtualCriptografada))
        {
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("senhaAtual", ResourceMensagensDeErro.SENHA_ATUAL_INVALIDA));
        }

        if (!resultado.IsValid)
        {
            var mensagens = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagens);
        }
    }
}