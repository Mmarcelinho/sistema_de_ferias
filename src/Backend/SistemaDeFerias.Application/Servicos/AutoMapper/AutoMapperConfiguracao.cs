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
        CreateMap<RequisicaoSetorJson, Domain.Entidades.Setor>();
        CreateMap<RequisicaoDepartamentoJson, Domain.Entidades.Departamento>();

        CreateMap<RequisicaoRegistrarAdminJson, Domain.Entidades.Admin>()
        .ForMember(destino => destino.Senha, config => config.Ignore());
        CreateMap<RequisicaoRegistrarFuncionarioJson, Domain.Entidades.Funcionario>()
        .ForMember(destino => destino.Senha, config => config.Ignore());

        CreateMap<RequisicaoSolicitarPedidoFeriasJson, Domain.Entidades.PedidoFerias>();
        CreateMap<RequisicaoAnalisarPedidoFeriasJson, Domain.Entidades.PedidoFerias>();
    }

    private void EntidadeParaResposta()
    {
        CreateMap<Domain.Entidades.Setor, RespostaSetorJson>();
        CreateMap<Domain.Entidades.Setor, RespostaSetorListJson>();

        CreateMap<Domain.Entidades.Departamento, RespostaDepartamentoJson>();
        CreateMap<Domain.Entidades.Departamento, Comunicacao.Respostas.Departamento.RespostaDepartamentoListJson>();

        CreateMap<Domain.Entidades.Funcionario, RespostaFuncionarioRegistradoJson>();
        CreateMap<Domain.Entidades.Funcionario, RespostaPerfilFuncionarioJson>();

        CreateMap<Domain.Entidades.Admin, RespostaAdminRegistradoJson>();
        CreateMap<Domain.Entidades.Admin, RespostaPerfilAdminJson>();

        CreateMap<Domain.Entidades.PedidoFerias, RespostaPedidoFeriasSolicitacaoJson>();
        CreateMap<Domain.Entidades.PedidoFerias, RespostaPedidoFeriasJson>();
        CreateMap<Domain.Entidades.PedidoFerias, RespostaDashboardPedidosFuncionarioJson>();
        CreateMap<Domain.Entidades.PedidoFerias, RespostaDashboardPedidosAdminJson>();
    }
}
