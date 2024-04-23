namespace SistemaDeFerias.Comunicacao.Requisicoes;

    public record RequisicaoAlterarSenhaJson
    {
        public string SenhaAtual { get; init; }

        public string NovaSenha { get; init; }
    }
