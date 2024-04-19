namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.RecuperarPerfil;

public class RecuperarPerfilFuncionarioUseCase : IRecuperarPerfilFuncionarioUseCase
{
    private readonly IMapper _mapper;
    private readonly IFuncionarioLogado _funcionarioLogado;

    public RecuperarPerfilFuncionarioUseCase(IMapper mapper, IFuncionarioLogado funcionarioLogado)
    {
        _mapper = mapper;
        _funcionarioLogado = funcionarioLogado;
    }

    public async Task<RespostaPerfilFuncionarioJson> Executar()
    {
        var funcionario = await _funcionarioLogado.RecuperarUsuario();

        return _mapper.Map<RespostaPerfilFuncionarioJson>(funcionario);
    }
}
