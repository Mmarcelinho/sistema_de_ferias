using Microsoft.Extensions.Configuration;

namespace SistemaDeFerias.Domain.Extension;

    public static class RepositorioExtension
    {
        public static string GetNomeDatabase(this IConfiguration configuration)
        {
            var nomeDatabase = configuration.GetConnectionString("NomeDatabase");

            return nomeDatabase;
        }

        public static string GetConexao(this IConfiguration configuration)
        {
            var conexao = configuration.GetConnectionString("Conexao");

            return conexao;
        }

        public static string GetConexaoCompleta(this IConfiguration configuration)
        {
            var nomeDatabase = configuration.GetNomeDatabase();
            var conexao = configuration.GetConexao();

            return $"Database={nomeDatabase};{conexao}";
        }
    }
