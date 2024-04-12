namespace SistemaDeFerias.Infrastructure.Mappings;

public class PedidoFeriasMap : IEntityTypeConfiguration<PedidoFerias>
{
    public void Configure(EntityTypeBuilder<PedidoFerias> builder)
    {
        builder.ToTable("PedidosFerias");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FuncionarioId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.Property(p => p.AdminId)
        .HasColumnType("bigint");

        builder.Property(p => p.DataPedido)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(p => p.DataInicio)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(p => p.DataFim)
       .IsRequired()
       .HasColumnType("datetime");

        builder.Property(p => p.Dias)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(P => P.Funcionario)
        .WithMany(p => p.PedidosFerias)
        .HasForeignKey(p => p.FuncionarioId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(P => P.Admin)
        .WithMany(p => p.PedidoFeriasAnalisados)
        .HasForeignKey(p => p.AdminId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}