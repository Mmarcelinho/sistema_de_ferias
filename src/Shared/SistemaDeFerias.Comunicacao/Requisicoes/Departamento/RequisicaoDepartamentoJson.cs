namespace SistemaDeFerias.Comunicacao.Requisicoes.Departamento;

    public record RequisicaoDepartamentoJson
    {
        public string Nome { get; init; }

        public long SetorId { get; init; }
    }
    
