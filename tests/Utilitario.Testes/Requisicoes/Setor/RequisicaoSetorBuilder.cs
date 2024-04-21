namespace Utilitario.Testes.Requisicoes.Setor;

public class RequisicaoSetorBuilder
{
    public static RequisicaoSetorJson Construir()
    {
        return new Faker<RequisicaoSetorJson>()
            .RuleFor(c => c.Nome, f => f.Name.JobArea());
    }
}
