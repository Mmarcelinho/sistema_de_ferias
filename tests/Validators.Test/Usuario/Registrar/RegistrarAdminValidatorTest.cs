namespace Validators.Test.Usuario.Registrar;

    public class RegistrarAdminValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new RegistrarAdminValidator();

            var requisicao = RequisicaoRegistrarAdminBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_Cargo_Vazio()
        {
            var validator = new RegistrarAdminValidator();

            var requisicao = RequisicaoRegistrarAdminBuilder.Construir();
            var requisicaoCargoVazio = requisicao with { Cargo = string.Empty };

            var resultado = validator.Validate(requisicaoCargoVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CARGO_ADMIN_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Departamento_Vazio()
        {
            var validator = new RegistrarAdminValidator();

            var requisicao = RequisicaoRegistrarAdminBuilder.Construir();
            var requisicaoDepartamentoVazio = requisicao with { DepartamentoId = 0 };

            var resultado = validator.Validate(requisicaoDepartamentoVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.DEPARTAMENTO_INVALIDO));
        }
    }
