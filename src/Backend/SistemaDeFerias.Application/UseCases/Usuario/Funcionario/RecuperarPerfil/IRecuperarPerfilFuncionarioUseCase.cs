namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.RecuperarPerfil;

    public interface IRecuperarPerfilFuncionarioUseCase
    {
        Task<RespostaPerfilFuncionarioJson> Executar();
    }