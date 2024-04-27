namespace Validators.Test.Usuario.Registrar;

    public class RegistrarFuncionarioValidatorTest
    {
        [Fact]
        public void Validar_Sucesso()
        {
            var validator = new RegistrarFuncionarioValidator();

            var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();

            var resultado = validator.Validate(requisicao);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_Erro_DataEntrada_Vazio()
        {
            var validator = new RegistrarFuncionarioValidator();

            var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();
            var requisicaoFuncaoVazio = requisicao with { DataEntrada = DateTime.MinValue };

            var resultado = validator.Validate(requisicaoFuncaoVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.DATA_ENTRADA_DO_FUNCIONARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Funcao_Vazio()
        {
            var validator = new RegistrarFuncionarioValidator();

            var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();
            var requisicaoFuncaoVazio = requisicao with { Funcao = string.Empty };

            var resultado = validator.Validate(requisicaoFuncaoVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.FUNCAO_FUNCIONARIO_EMBRANCO));
        }

        [Fact]
        public void Validar_Erro_Departamento_Vazio()
        {
            var validator = new RegistrarFuncionarioValidator();

            var requisicao = RequisicaoRegistrarFuncionarioBuilder.Construir();
            var requisicaoDepartamentoVazio = requisicao with { DepartamentoId = 0 };

            var resultado = validator.Validate(requisicaoDepartamentoVazio);

            resultado.IsValid.Should().BeFalse();

            resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.DEPARTAMENTO_INVALIDO));
        }
    }
