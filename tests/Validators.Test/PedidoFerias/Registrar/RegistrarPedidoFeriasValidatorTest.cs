namespace Validators.Test.PedidoFerias.Registrar;

    public class RegistrarPedidoFeriasValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new RegistrarPedidoFeriasValidator();

            var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_DataInicio_Vazio()
        {
            var validator = new RegistrarPedidoFeriasValidator();

            var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
            var requisicaoDataInicioVazio = requisicao with { DataInicio = DateTime.MinValue };

            var resultado = validator.Validate(requisicaoDataInicioVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.DATA_INICIO_DO_PEDIDOFERIAS_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Quantidade_Dias_Vazio()
        {
            var validator = new RegistrarPedidoFeriasValidator();

            var requisicao = RequisicaoSolicitarPedidoFeriasBuilder.Construir();
            var requisicaoDiasVazio = requisicao with { Dias = 0 };

            var resultado = validator.Validate(requisicaoDiasVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.QTD_DIAS_DO_PEDIDOFERIAS));
        }
    }
