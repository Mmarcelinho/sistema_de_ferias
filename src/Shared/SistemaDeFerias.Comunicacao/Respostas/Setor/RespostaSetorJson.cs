namespace SistemaDeFerias.Comunicacao.Respostas.Setor;

    public record RespostaSetorJson(string Id, string Nome);

    public record RespostaSetorListJson
    {
        public List<RespostaSetorJson> Setores { get; init; }
    }