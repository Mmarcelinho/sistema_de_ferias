namespace SistemaDeFerias.Comunicacao.Requisicoes.Funcionario;

    public record RequisicaoRegistrarFuncionarioJson(string Nome, string Email, string Senha, string Telefone, string Funcao, DateTime DataEntrada, long DepartamentoId);