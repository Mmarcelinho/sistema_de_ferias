namespace SistemaDeFerias.Infrastructure.Mappings;

public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(p => p.SetorId)
        .IsRequired()
        .HasColumnType("long");

        builder.HasOne(p => p.Setor)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.SetorId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
