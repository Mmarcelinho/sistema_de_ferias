namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;

    public interface IRegistrarFuncionarioUseCase
    {
        Task<RespostaFuncionarioRegistradoJson> Executar(RequisicaoRegistrarFuncionarioJson requisicao);
    }
