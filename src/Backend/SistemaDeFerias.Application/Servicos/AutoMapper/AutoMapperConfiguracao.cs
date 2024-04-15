namespace SistemaDeFerias.Application.Servicos.AutoMapper;

    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao()
        {
            RequisicaoParaEntidade();
            EntidadeParaResposta();
        }

        private void RequisicaoParaEntidade()
        {
            CreateMap<Comunicacao.Requisicoes.Setor.RequisicaoSetorJson, Domain.Entidades.Setor>();

            CreateMap<Comunicacao.Requisicoes.Departamento.RequisicaoDepartamentoJson, Domain.Entidades.Departamento>();

            CreateMap<Comunicacao.Requisicoes.Admin.RequisicaoRegistrarAdminJson, Domain.Entidades.Admin>()
            .ForMember(destino => destino.Senha, config => config.Ignore());

            CreateMap<Comunicacao.Requisicoes.Funcionario.RequisicaoRegistrarFuncionarioJson, Domain.Entidades.Funcionario>()
            .ForMember(destino => destino.Senha, config => config.Ignore());

            CreateMap<Comunicacao.Requisicoes.PedidoFerias.RequisicaoSolicitarPedidoFeriasJson, Domain.Entidades.PedidoFerias>();

            CreateMap<Comunicacao.Requisicoes.PedidoFerias.RequisicaoAnalisarPedidoFeriasJson, Domain.Entidades.PedidoFerias>();
        }

        private void EntidadeParaResposta()
        {
            CreateMap<Domain.Entidades.Setor, Comunicacao.Respostas.Setor.RespostaSetorJson>();

            CreateMap<Domain.Entidades.Departamento, Comunicacao.Respostas.Departamento.RespostaDepartamentoJson>();

            CreateMap<Domain.Entidades.Funcionario, Comunicacao.Respostas.Funcionario.RespostaFuncionarioRegistradoJson>();
            
            CreateMap<Domain.Entidades.Funcionario, Comunicacao.Respostas.Funcionario.RespostaLoginFuncionarioJson>();

            CreateMap<Domain.Entidades.Funcionario, Comunicacao.Respostas.Funcionario.RespostaPerfilFuncionarioJson>();

            CreateMap<Domain.Entidades.Admin, Comunicacao.Respostas.Admin.RespostaAdminRegistradoJson>();

            CreateMap<Domain.Entidades.Admin, Comunicacao.Respostas.Admin.RespostaLoginAdminJson>();

            CreateMap<Domain.Entidades.Admin, Comunicacao.Respostas.Admin.RespostaPerfilAdminJson>();

            CreateMap<Domain.Entidades.PedidoFerias, Comunicacao.Respostas.PedidoFerias.RespostaPedidoFeriasSolicitacaoJson>();

            CreateMap<Domain.Entidades.PedidoFerias, Comunicacao.Respostas.Funcionario.RespostaDashboardPedidosFuncionarioJson>();

            CreateMap<Domain.Entidades.PedidoFerias, Comunicacao.Respostas.Admin.RespostaDashboardPedidosAdminJson>();
        }
    }
