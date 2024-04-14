namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.RecuperarPerfil;

public class RecuperarPerfilAdminUseCase : IRecuperarPerfilAdminUseCase
{
    private readonly IMapper _mapper;
    private readonly IFuncionarioLogado _adminLogado;

    public RecuperarPerfilAdminUseCase(IMapper mapper, IFuncionarioLogado adminLogado)
    {
        _mapper = mapper;
        _adminLogado = adminLogado;
    }

    public async Task<RespostaPerfilAdminJson> Executar()
    {
        var admin = await _adminLogado.RecuperarFuncionario();

        return _mapper.Map<RespostaPerfilAdminJson>(admin);
    }
}
