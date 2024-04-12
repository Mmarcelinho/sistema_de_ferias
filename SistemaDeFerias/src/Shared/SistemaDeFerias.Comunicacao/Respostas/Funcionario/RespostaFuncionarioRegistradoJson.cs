namespace SistemaDeFerias.Comunicacao.Respostas.Funcionario;

    public record RespostaFuncionarioRegistradoJson(string Id, string Nome, string Email, string Senha, string Funcao, string Entrada, string DepartamentoId);
