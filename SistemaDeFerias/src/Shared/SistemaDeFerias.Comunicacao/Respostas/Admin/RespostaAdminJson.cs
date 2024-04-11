namespace SistemaDeFerias.Comunicacao.Respostas.Admin;

    public record RespostaAdminJson(string Nome, string Email, string Senha, string Cargo, long DepartamentoId);
