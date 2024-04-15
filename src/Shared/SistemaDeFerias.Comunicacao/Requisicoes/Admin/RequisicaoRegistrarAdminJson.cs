namespace SistemaDeFerias.Comunicacao.Requisicoes.Admin;

    public record RequisicaoRegistrarAdminJson(string Nome, string Email, string Senha, string Telefone, string Cargo, long DepartamentoId);
