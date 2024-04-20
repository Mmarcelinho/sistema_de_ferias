namespace SistemaDeFerias.Application.UseCases.Usuario.Funcionario.Registrar;

public class RegistrarFuncionarioValidator : AbstractValidator<RequisicaoRegistrarFuncionarioJson>
{
    public RegistrarFuncionarioValidator()
    {
        RuleFor(x => x).SetValidator(new RegistrarUsuarioValidator());
        RuleFor(c => c.DataEntrada).NotEmpty().WithMessage(ResourceMensagensDeErro.DATA_ENTRADA_DO_FUNCIONARIO_EMBRANCO);
        RuleFor(c => c.Funcao).NotEmpty().WithMessage(ResourceMensagensDeErro.FUNCAO_FUNCIONARIO_EMBRANCO);
        RuleFor(c => c.DepartamentoId).NotEmpty().WithMessage(ResourceMensagensDeErro.DEPARTAMENTO_INVALIDO);
    }
}