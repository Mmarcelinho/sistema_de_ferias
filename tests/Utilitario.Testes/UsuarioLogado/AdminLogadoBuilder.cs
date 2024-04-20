using Moq;
using SistemaDeFerias.Application.Servicos.UsuarioLogado.Admin;

namespace Utilitario.Testes.UsuarioLogado;

    public class AdminLogadoBuilder
    {
        private static AdminLogadoBuilder _instance;

        private readonly Mock<IAdminLogado> _repositorio;

        private AdminLogadoBuilder()
        {
            if(_repositorio is null)
            _repositorio = new Mock<IAdminLogado>();
        }

        public static AdminLogadoBuilder Instancia()
        {
            _instance = new AdminLogadoBuilder();
            return _instance;
        }

        public AdminLogadoBuilder RecuperarUsuario(Admin admin)
        {
            _repositorio.Setup(c => c.RecuperarUsuario()).ReturnsAsync(admin);

            return this;
        }

        public IAdminLogado Construir()
        {
            return _repositorio.Object;
        }
        
    }
