using SistemaDeFerias.Comunicacao.Requisicoes.Usuario;

namespace SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;

public record RequisicaoRegistrarFuncionarioJson : RequisicaoRegistrarUsuarioJson
{
    public string Funcao { get; init; }

    public DateTime DataEntrada { get; set; }

    public long DepartamentoId { get; init; }
}
