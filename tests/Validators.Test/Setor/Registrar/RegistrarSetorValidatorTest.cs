namespace Validators.Test.Setor.Registrar;

    public class RegistrarSetorValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new RegistrarSetorValidator();

            var requisicao = RequisicaoSetorBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_Nome_Vazio()
        {
            var validator = new RegistrarSetorValidator();

            var requisicao = RequisicaoSetorBuilder.Construir();
            var requisicaoSemNome = requisicao with { Nome = string.Empty };

            var resultado = validator.Validate(requisicaoSemNome);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_DO_SETOR_EMBRANCO));
        }
    }
