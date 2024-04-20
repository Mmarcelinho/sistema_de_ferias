namespace Utilitario.Testes.Requisicoes.Departamento
{
    public class RequisicaoDepartamentoBuilder
    {
        public static RequisicaoDepartamentoJson Construir()
    {
        return new Faker<RequisicaoDepartamentoJson>()
            .RuleFor(c => c.Nome, f => f.Name.JobArea());
    }
    }
}