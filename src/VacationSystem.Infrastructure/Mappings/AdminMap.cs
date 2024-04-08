using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationSystem.Domain.Entities;


namespace VacationSystem.Infrastructure.Mappings;

public class AdminMap : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(p => p.Cargo)
        .IsRequired()
        .HasColumnType("varchar(30)");

        builder.Property(p => p.LevelAcesso)
        .IsRequired()
        .HasColumnType("varchar(30)");
    }
}
