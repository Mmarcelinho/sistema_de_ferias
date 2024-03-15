using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationSystem.Domain.Entities;


namespace VacationSystem.Infrastructure.Mappings;

public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasColumnType("varchar(50)");

         builder.Property(p => p.Funcao)
        .IsRequired()
        .HasColumnType("varchar(50)");

         builder.Property(p => p.Setor)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(p => p.DataInicio)
       .IsRequired()
       .HasColumnType("datetime");

       builder.Property(p => p.DepartamentoId)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(P => P.Departamento)
        .WithMany(p => p.Funcionarios)
        .HasForeignKey(p => p.DepartamentoId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}