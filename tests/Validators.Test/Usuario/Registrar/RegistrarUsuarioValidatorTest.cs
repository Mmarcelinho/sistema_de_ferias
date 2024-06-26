namespace Validators.Test.Usuario.Registrar;

    public class RegistrarUsuarioValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_Nome_Vazio()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoNomeVazio = requisicao with { Nome = string.Empty };

            var resultado = validator.Validate(requisicaoNomeVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Email_Vazio()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoEmailVazio = requisicao with { Email = string.Empty };

            var resultado = validator.Validate(requisicaoEmailVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Senha_Vazio()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoSenhaVazio = requisicao with { Senha = string.Empty };

            var resultado = validator.Validate(requisicaoSenhaVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Telefone_Vazio()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoTelefoneVazio = requisicao with { Telefone = string.Empty };

            var resultado = validator.Validate(requisicaoTelefoneVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.TELEFONE_USUARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Email_Invalido()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoEmailInvalido = requisicao with { Email = "abc" };

            var resultado = validator.Validate(requisicaoEmailInvalido);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO));
        }

        [Fact]
        public void Validar_Erro_Telefone_Invalido()
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir();
            var requisicaoTelefoneInvalido = requisicao with { Telefone = "71 99" };

            var resultado = validator.Validate(requisicaoTelefoneInvalido);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.TELEFONE_USUARIO_INVALIDO));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Validar_Erro_Senha_Invalido(int tamanhoSenha)
        {
            var validator = new RegistrarUsuarioValidator();

            var requisicao = RequisicaoRegistrarUsuarioBuilder.Construir(tamanhoSenha);

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
        }      
    }
