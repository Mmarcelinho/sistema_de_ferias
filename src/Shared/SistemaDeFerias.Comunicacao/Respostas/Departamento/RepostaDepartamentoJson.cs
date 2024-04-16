namespace SistemaDeFerias.Comunicacao.Respostas.Departamento;

    public record RespostaDepartamentoJson(string Id, string Nome);

    public record RespostaDepartamentoListJson
    {
        public List<RespostaDepartamentoJson> Departamentos { get; init; }
    }