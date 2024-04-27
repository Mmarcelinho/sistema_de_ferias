namespace WebApi.Test;

public class ContextSeedInMemory
{
    public static (Admin admin, string senha) SeedAdminComPedido(SistemaDeFeriasContext context)
    {
        (var admin, string senha) = AdminBuilder.Construir();
        var pedido = PedidoFeriasBuilder.Construir(admin.Id);
        pedido.AdminId = admin.Id;
        pedido.Status = SistemaDeFerias.Domain.Enum.Status.Aprovado;

        context.Admins.Add(admin);
        context.PedidoFerias.Add(pedido);

        context.SaveChanges();

        return (admin, senha);
    }

    public static (Admin admin, string senha) SeedAdminSemPedido(SistemaDeFeriasContext context)
    {
        (var admin, string senha) = AdminBuilder.Construir(2);

        context.Admins.Add(admin);

        context.SaveChanges();

        return (admin, senha);
    }

    public static (Funcionario funcionario, string senha) SeedFuncionarioComPedido(SistemaDeFeriasContext context)
    {
        (var funcionario, string senha) = FuncionarioBuilder.Construir();
        var pedido = PedidoFeriasBuilder.Construir(2);
        pedido.FuncionarioId = 1;

        context.Funcionarios.Add(funcionario);
        context.PedidoFerias.Add(pedido);

        context.SaveChanges();

        return (funcionario, senha);
    }

    public static (Funcionario funcionario, string senha) SeedFuncionarioSemPedido(SistemaDeFeriasContext context)
    {
        (var funcionario, string senha) = FuncionarioBuilder.Construir(2);

        context.Funcionarios.Add(funcionario);

        context.SaveChanges();

        return (funcionario, senha);
    }

    public static void SeedSetorEDepartamento(SistemaDeFeriasContext context)
    {
        var setor = SetorBuilder.Construir();
        var departamento = DepartamentoBuilder.Construir();

        context.Setores.Add(setor);
        context.Departamentos.Add(departamento);

        context.SaveChanges();
    }

    
}
