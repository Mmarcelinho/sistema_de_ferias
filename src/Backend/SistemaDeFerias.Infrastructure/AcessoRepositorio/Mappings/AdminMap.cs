namespace SistemaDeFerias.Infrastructure.Mappings;

public class AdminMap : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(p => p.Email)
        .IsRequired();

        builder.Property(p => p.Senha)
        .IsRequired()
        .HasColumnType("varchar(2000)");

        builder.Property(p => p.Telefone)
        .IsRequired()
        .HasColumnType("varchar(14)");

        builder.Property(p => p.Cargo)
        .IsRequired()
        .HasColumnType("varchar(30)");

        builder.Property(p => p.Administrador)
        .HasColumnType("bit")
        .HasDefaultValue(true);

        builder.Property(p => p.DepartamentoId)
        .IsRequired()
        .HasColumnType("bigint");

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Admins)
        .HasForeignKey(p => p.DepartamentoId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
