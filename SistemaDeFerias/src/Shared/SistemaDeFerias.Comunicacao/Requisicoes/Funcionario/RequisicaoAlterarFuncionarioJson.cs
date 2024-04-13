namespace SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;

    public record RequisicaoAlterarFuncionarioJson(string Nome, string Email, string Senha, string Funcao, DateOnly Entrada, long DepartamentoId);
