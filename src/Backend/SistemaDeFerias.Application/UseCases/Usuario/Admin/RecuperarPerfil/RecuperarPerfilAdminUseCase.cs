namespace SistemaDeFerias.Application.UseCases.Usuario.Admin.RecuperarPerfil;

public class RecuperarPerfilAdminUseCase : IRecuperarPerfilAdminUseCase
{
    private readonly IMapper _mapper;
    private readonly IAdminLogado _adminLogado;

    public RecuperarPerfilAdminUseCase(IMapper mapper, IAdminLogado adminLogado)
    {
        _mapper = mapper;
        _adminLogado = adminLogado;
    }

    public async Task<RespostaPerfilAdminJson> Executar()
    {
        var admin = await _adminLogado.RecuperarAdmin();

        return _mapper.Map<RespostaPerfilAdminJson>(admin);
    }
}
