namespace SistemaDeFerias.Comunicacao.Respostas.Admin;

    public record RespostaAdminRegistradoJson(string Id, string Nome, string Email, string Senha, string Cargo, long DepartamentoId);
