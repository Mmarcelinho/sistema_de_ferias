﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeFerias.Infrastructure.AcessoRepositorio;

#nullable disable

namespace SistemaDeFerias.Infrastructure.Migrations
{
    [DbContext(typeof(SistemaDeFeriasContext))]
    [Migration("20240410032252_versao000001")]
    partial class versao000001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Administrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<long>("DepartamentoId")
                        .HasColumnType("long");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Departamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<long>("SetorId")
                        .HasColumnType("long");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Departamentos", (string)null);
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataUltimaFerias")
                        .HasColumnType("datetime");

                    b.Property<long>("DepartamentoId")
                        .HasColumnType("long");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Funcionarios", (string)null);
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.PedidoFerias", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AdminId")
                        .HasColumnType("long");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<long>("FuncionarioId")
                        .HasColumnType("long");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("PedidosFerias", (string)null);
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Setor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Admin", b =>
                {
                    b.HasOne("SistemaDeFerias.Domain.Entidades.Departamento", "Departamento")
                        .WithMany("Admins")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Departamento", b =>
                {
                    b.HasOne("SistemaDeFerias.Domain.Entidades.Setor", "Setor")
                        .WithMany("Departamentos")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Funcionario", b =>
                {
                    b.HasOne("SistemaDeFerias.Domain.Entidades.Departamento", "Departamento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.PedidoFerias", b =>
                {
                    b.HasOne("SistemaDeFerias.Domain.Entidades.Admin", "Admin")
                        .WithMany("PedidoFeriasAnalisados")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeFerias.Domain.Entidades.Funcionario", "Funcionario")
                        .WithMany("PedidosFerias")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Admin", b =>
                {
                    b.Navigation("PedidoFeriasAnalisados");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Departamento", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Funcionario", b =>
                {
                    b.Navigation("PedidosFerias");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.Setor", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
