namespace SistemaDeFerias.Application.UseCases.PedidoFerias.Atualizar
{
    public class AtualizarPedidoFeriasUseCase : IAtualizarPedidoFeriasUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IFuncionarioLogado _funcionarioLogado;
        private readonly IPedidoFeriasUpdateOnlyRepositorio _repositorio;

        public AtualizarPedidoFeriasUseCase(IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, IFuncionarioLogado funcionarioLogado, IPedidoFeriasUpdateOnlyRepositorio repositorio)
        {
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _funcionarioLogado = funcionarioLogado;
            _repositorio = repositorio;
        }

        public async Task Executar(long id, RequisicaoSolicitarPedidoFeriasJson requisicao)
        {
            var funcionario = await _funcionarioLogado.RecuperarFuncionario();
            var pedido = await _repositorio.RecuperarPorId(id);

            Validar(funcionario, pedido, requisicao);
            ValidarStatus(pedido);

            _mapper.Map(requisicao, pedido);
            _repositorio.Atualizar(pedido);

            await _unidadeDeTrabalho.Commit();
        }

        private static void Validar(Domain.Entidades.Funcionario funcionario, Domain.Entidades.PedidoFerias pedido, RequisicaoSolicitarPedidoFeriasJson requisicao)
        {
            if (pedido is null || pedido.FuncionarioId == funcionario.Id)
                throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.PEDIDO_NAO_ENCONTRADO });

            var validator = new AtualizarPedidoFeriasValidator();
            var resultado = validator.Validate(requisicao);

            if (!resultado.IsValid)
            {
                var mensagesDeErro = resultado.Errors.Select(c => c.ErrorMessage).ToList();
                throw new ErrosDeValidacaoException(mensagesDeErro);
            }
        }

        private static void ValidarStatus(Domain.Entidades.PedidoFerias pedido)
        {
            if (pedido.Status == Domain.Enum.Status.Aprovado || pedido.Status == Domain.Enum.Status.Negado)
                throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.ALTERAR_PEDIDO_ANALISADO });
        }
    }
}