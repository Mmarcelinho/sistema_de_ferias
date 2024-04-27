namespace Validators.Test.PedidoFerias.Analisar;

    public class AnalisarPedidoFeriasValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new AnalisarPedidoFeriasValidator();

            var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_Status_Pendente()
        {
            var validator = new AnalisarPedidoFeriasValidator();

            var requisicao = RequisicaoAnalisarPedidoFeriasBuilder.Construir();
            var requisicaoStatusPendente = requisicao with { Status = SistemaDeFerias.Comunicacao.Enum.Status.Pendente };

            var resultado = validator.Validate(requisicaoStatusPendente);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.STATUS_DA_SOLICITACAO_INVALIDO));
        }
    }
