using SistemaDeFerias.Comunicacao.Requisicoes.Usuario;

namespace SistemaDeFerias.Comunicacao.Requisicoes.Admin;

public record RequisicaoRegistrarAdminJson : RequisicaoRegistrarUsuarioJson
{
    public string Cargo { get; init; }

    public long DepartamentoId { get; init; }

}

