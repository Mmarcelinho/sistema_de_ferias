namespace SistemaDeFerias.Application.UseCases.Usuario.RecuperarPerfil;

public class RecuperarPerfilUsuarioUseCase<TEntidade> : IRecuperarPerfilUsuarioUseCase<TEntidade> where TEntidade : Domain.Entidades.Usuario
{
    private readonly IMapper _mapper;
    private readonly IUsuarioLogado<TEntidade> _usuarioLogado;

    public RecuperarPerfilUsuarioUseCase(IMapper mapper, IUsuarioLogado<TEntidade> usuarioLogado)
    {
        _mapper = mapper;
        _usuarioLogado = usuarioLogado;
    }

    public async Task<RespostaPerfilUsuarioJson> Executar()
    {
        var usuario = await _usuarioLogado.RecuperarUsuario();

        return _mapper.Map<RespostaPerfilUsuarioJson>(usuario);
    }
}
