using Moq;
using SistemaDeFerias.Application.Servicos.UsuarioLogado.Funcionario;

namespace Utilitario.Testes.UsuarioLogado;

    public class FuncionarioLogadoBuilder
    {
        private static FuncionarioLogadoBuilder _instance;

        private readonly Mock<IFuncionarioLogado> _repositorio;

        private FuncionarioLogadoBuilder()
        {
            if(_repositorio is null)
            _repositorio = new Mock<IFuncionarioLogado>();
        }

        public static FuncionarioLogadoBuilder Instancia()
        {
            _instance = new FuncionarioLogadoBuilder();
            return _instance;
        }

        public FuncionarioLogadoBuilder RecuperarUsuario(Funcionario funcionario)
        {
            _repositorio.Setup(c => c.RecuperarUsuario()).ReturnsAsync(funcionario);

            return this;
        }

        public IFuncionarioLogado Construir()
        {
            return _repositorio.Object;
        }
        
    }
