namespace Utilitario.Testes.Token;

    public class TokenControllerBuilder
    {
        public static TokenController Instancia()
        {
            return new TokenController(1000, "e5ce08f8fe05d4785d69df11e56c5c605af4f320878e0618d5b543f5ea4eddae");
        }

        public static TokenController TokenExpirado()
        {
            return new TokenController(0.0166667, "e5ce08f8fe05d4785d69df11e56c5c605af4f320878e0618d5b543f5ea4eddae");
        }
    }
