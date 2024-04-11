namespace SistemaDeFerias.Comunicacao.Respostas.Funcionario;

    public record RespostaFuncionarioJson(string Nome, string Email, string Senha, string Funcao, DateTime Entrada, long DepartamentoId);
