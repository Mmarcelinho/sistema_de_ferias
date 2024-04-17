namespace SistemaDeFerias.Infrastructure.Mappings;

public class SetorMap : IEntityTypeConfiguration<Setor>
{
    public void Configure(EntityTypeBuilder<Setor> builder)
    {
        builder.ToTable("Setores");
        
        builder.HasKey(p => p.Id);

        builder.HasData(
            new Setor
            {
                Id = 1,
                Nome = "Setor1",
            }
        );
    }
}
