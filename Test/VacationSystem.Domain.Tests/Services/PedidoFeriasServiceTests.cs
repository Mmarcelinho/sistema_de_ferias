namespace VacationSystem.Domain.Tests.Services;

public class PedidoFeriasServiceTests
    {
        private PedidoFeriasService _pedidoFeriasService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly Funcionario _funcionario;

        private readonly Admin _admin;

        public PedidoFeriasServiceTests()
        {
            _funcionario = new Funcionario(1, "Funcionário1", "Função1", "Setor1", DateTime.Now.AddYears(-1),1);

            _admin = new Admin(1, "Admin1", "Cargo1", "LevelAcesso1");

            _unitOfWork = Substitute.For<IUnitOfWork>();
            
            _pedidoFeriasService = new PedidoFeriasService(_unitOfWork);
        }

        [Fact]
        public void AprovarPedidoFerias_Deve_Criar_Pedido_Quando_Dados_Validos()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;

            var pedido = _pedidoFeriasService.PedirFerias(_funcionario, dataInicio, dias);

            _unitOfWork.PedidoFeriasRepository.Received(1).AdicionarAsync(pedido);

            Assert.NotNull(pedido);
            Assert.Equal(dataInicio, pedido.DataInicio);
            Assert.Equal(dias, pedido.Dias);
        }

        [Fact]
        public void AprovarPedidoFerias_Quando_Nao_Elegivel_Deve_Lancar_Excecao()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;
            var funcionario = new Funcionario(1, "Funcionário1", "Função1", "Setor1", DateTime.Now.AddMonths(-10),1);

            Assert.Throws<InvalidOperationException>( () => _pedidoFeriasService.PedirFerias(funcionario, dataInicio, dias));
        }

        [Fact]
        public void AprovarPedidoFerias_Funcionario_Com_Menos_De_Um_Ano_De_Trabalho_Pos_Ferias_Deve_Ser_Nao_Elegivel()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;
            var funcionario = new Funcionario(1, "Funcionário1", "Função1", "Setor1", DateTime.Now.AddYears(-4),DateTime.Now.AddMonths(-6),1);

            Assert.Throws<InvalidOperationException>( () => _pedidoFeriasService.PedirFerias(funcionario, dataInicio, dias));
        }

         [Fact]
        public void AprovarPedidoFerias_Deve_Atualizar_Status_Quando_Aprovado()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;     
            var pedido = _pedidoFeriasService.PedirFerias(_funcionario, dataInicio, dias);
            var status = "Aprovado";

            var pedidoAprovado = _pedidoFeriasService.AprovarPedidoFerias(pedido, _admin, true);

            _unitOfWork.PedidoFeriasRepository.Received(1).AtualizarAsync(pedido);

            Assert.Equal(status, pedidoAprovado.Status);
        }

        [Fact]
        public void AprovarPedidoFerias_Deve_Atualizar_Status_Quando_Negado()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;     
            var pedido = _pedidoFeriasService.PedirFerias(_funcionario, dataInicio, dias);
            var status = "Negado";

            var pedidoAprovado = _pedidoFeriasService.AprovarPedidoFerias(pedido, _admin, false);

            _unitOfWork.PedidoFeriasRepository.Received(1).AtualizarAsync(pedido);

            Assert.Equal(status, pedidoAprovado.Status);
        }

        [Fact]
        public void AprovarPedidoFerias_Quando_Status_Nao_For_Pendente_Deve_Lancar_Excecao()
        {
            var dataInicio = DateTime.Now.AddDays(5);
            var dias = 15;     
            var pedido = _pedidoFeriasService.PedirFerias(_funcionario, dataInicio, dias);
            var status = "Negado";
            pedido.Atualizar(status);

            Assert.Throws<InvalidOperationException>( () => _pedidoFeriasService.AprovarPedidoFerias(pedido, _admin, true));
        }
    }
