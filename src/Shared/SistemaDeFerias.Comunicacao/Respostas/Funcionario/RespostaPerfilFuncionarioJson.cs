using SistemaDeFerias.Comunicacao.Respostas.Usuario;

namespace SistemaDeFerias.Comunicacao.Respostas.Funcionario;

    public record RespostaPerfilFuncionarioJson(string Nome, string Email, string Telefone, string DepartamentoId) : RespostaPerfilUsuarioJson( Nome, Email, Telefone);
