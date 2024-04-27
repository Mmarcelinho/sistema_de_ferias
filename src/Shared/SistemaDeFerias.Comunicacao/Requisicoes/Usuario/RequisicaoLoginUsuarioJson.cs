namespace SistemaDeFerias.Comunicacao.Requisicoes.Usuario;

    public record RequisicaoLoginUsuarioJson
    {
        public string Email { get; init; }

        public string Senha { get; init; }
    }
