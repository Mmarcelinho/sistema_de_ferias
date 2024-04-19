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
    [Migration("20240418064241_version000001")]
    partial class version000001
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
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Admins", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Administrador = true,
                            Cargo = "Gerente Geral",
                            DataCriacao = new DateTime(2024, 4, 18, 6, 42, 37, 411, DateTimeKind.Utc).AddTicks(9920),
                            DepartamentoId = 1L,
                            Email = "admin@empresa.com",
                            Nome = "Admin Principal",
                            Senha = "ce333f1a30e5c9f4767b545a8750afa23f2f4d9c24ca5a2bef40607fea9133d466cb640e06d110341d558feefeccc4bdb7c25c3454c3af993dbd0ab7ffffb396",
                            Telefone = "71 9 9999-9999"
                        });
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
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Departamentos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DataCriacao = new DateTime(2024, 4, 18, 6, 42, 37, 415, DateTimeKind.Utc).AddTicks(4640),
                            Nome = "Departamento1",
                            SetorId = 1L
                        });
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
                        .HasColumnType("date");

                    b.Property<DateTime?>("DataUltimaFerias")
                        .HasColumnType("date");

                    b.Property<long>("DepartamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

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

                    b.Property<long?>("AdminId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("date");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<long>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

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

                    b.ToTable("Setores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DataCriacao = new DateTime(2024, 4, 18, 6, 42, 37, 423, DateTimeKind.Utc).AddTicks(2094),
                            Nome = "Setor1"
                        });
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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("SistemaDeFerias.Domain.Entidades.PedidoFerias", b =>
                {
                    b.HasOne("SistemaDeFerias.Domain.Entidades.Admin", "Admin")
                        .WithMany("PedidoFeriasAnalisados")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction);

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