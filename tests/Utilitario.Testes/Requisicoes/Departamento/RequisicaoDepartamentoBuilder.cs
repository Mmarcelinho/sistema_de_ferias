namespace Utilitario.Testes.Requisicoes.Departamento;

    public class RequisicaoDepartamentoBuilder
    {
        public static RequisicaoDepartamentoJson Construir(long id)
    {
        return new Faker<RequisicaoDepartamentoJson>()
            .RuleFor(c => c.Nome, f => f.Name.JobArea())
            .RuleFor(c => c.SetorId, _ => id);
    }

    }
