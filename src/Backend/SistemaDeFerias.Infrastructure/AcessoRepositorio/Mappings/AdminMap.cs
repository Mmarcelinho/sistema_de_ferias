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

        builder.HasData(
            new Admin
            {
                Id = 1,
                Nome = "Admin Principal",
                Email = "admin@empresa.com",
                Senha = "ce333f1a30e5c9f4767b545a8750afa23f2f4d9c24ca5a2bef40607fea9133d466cb640e06d110341d558feefeccc4bdb7c25c3454c3af993dbd0ab7ffffb396", 
                Telefone = "71 9 9999-9999",
                Cargo = "Gerente Geral",
                Administrador = true,
                DepartamentoId = 1
            }
        );
        
    }
}
