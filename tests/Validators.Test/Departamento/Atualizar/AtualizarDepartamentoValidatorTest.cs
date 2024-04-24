namespace Validators.Test.Departamento.Atualizar;

    public class AtualizarDepartamentoValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            long departamentoId = 1;

            var validator = new AtualizarDepartamentoValidator();

            var requisicao = RequisicaoDepartamentoBuilder.Construir(departamentoId);

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_Nome_Vazio()
        {
            long departamentoId = 1;

            var validator = new AtualizarDepartamentoValidator();

            var requisicao = RequisicaoDepartamentoBuilder.Construir(departamentoId);
            var requisicaoSemNome = requisicao with { Nome = string.Empty };

            var resultado = validator.Validate(requisicaoSemNome);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_DO_DEPARTAMENTO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Setor_Invalido()
        {
            long departamentoId = 1;

            var validator = new AtualizarDepartamentoValidator();

            var requisicao = RequisicaoDepartamentoBuilder.Construir(departamentoId);
            var requisicaoSemSetor = requisicao with { SetorId = 0 };

            var resultado = validator.Validate(requisicaoSemSetor);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SETOR_INVALIDO));
        }
    }
