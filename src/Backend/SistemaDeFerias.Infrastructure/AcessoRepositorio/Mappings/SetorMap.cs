namespace SistemaDeFerias.Infrastructure.Mappings;

public class SetorMap : IEntityTypeConfiguration<Setor>
{
    public void Configure(EntityTypeBuilder<Setor> builder)
    {
        builder.ToTable("Setores");
        
        builder.HasKey(p => p.Id);
    }
}
