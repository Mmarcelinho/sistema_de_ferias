using SistemaDeFerias.Comunicacao.Respostas.Usuario;

namespace SistemaDeFerias.Comunicacao.Respostas.Admin;

    public record RespostaPerfilAdminJson(string Nome, string Email, string Telefone, string Cargo) : RespostaPerfilUsuarioJson( Nome, Email, Telefone);