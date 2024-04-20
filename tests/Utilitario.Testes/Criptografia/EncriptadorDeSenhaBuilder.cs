namespace Utilitario.Testes.Criptografia;

    public class EncriptadorDeSenhaBuilder
    {
        public static EncriptadorDeSenha Instancia()
        {
            return new EncriptadorDeSenha("ABCD123");
        }
    }
