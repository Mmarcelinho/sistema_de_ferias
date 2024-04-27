namespace SistemaDeFerias.Comunicacao.Requisicoes.Usuario;

public record RequisicaoRegistrarUsuarioJson
{
    public string Nome { get; init; }

    public string Email { get; init; }

    public string Senha { get; init; }

    public string Telefone { get; init; }
}