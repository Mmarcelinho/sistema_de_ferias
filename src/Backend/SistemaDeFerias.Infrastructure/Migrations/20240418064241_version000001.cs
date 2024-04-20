using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeFerias.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class version000001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    SetorId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(30)", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DepartamentoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", nullable: false),
                    Funcao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    DataUltimaFerias = table.Column<DateTime>(type: "date", nullable: true),
                    DepartamentoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidosFerias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPedido = table.Column<DateTime>(type: "date", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "date", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<long>(type: "bigint", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosFerias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosFerias_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosFerias_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: ["Id", "DataCriacao", "Nome"],
                values: new object[] { 1L, new DateTime(2024, 4, 18, 6, 42, 37, 423, DateTimeKind.Utc).AddTicks(2094), "Setor1" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: ["Id", "DataCriacao", "Nome", "SetorId"],
                values: new object[] { 1L, new DateTime(2024, 4, 18, 6, 42, 37, 415, DateTimeKind.Utc).AddTicks(4640), "Departamento1", 1L });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: ["Id", "Administrador", "Cargo", "DataCriacao", "DepartamentoId", "Email", "Nome", "Senha", "Telefone"],
                values: new object[] { 1L, true, "Gerente Geral", new DateTime(2024, 4, 18, 6, 42, 37, 411, DateTimeKind.Utc).AddTicks(9920), 1L, "admin@empresa.com", "Admin Principal", "ce333f1a30e5c9f4767b545a8750afa23f2f4d9c24ca5a2bef40607fea9133d466cb640e06d110341d558feefeccc4bdb7c25c3454c3af993dbd0ab7ffffb396", "71 9 9999-9999" });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_DepartamentoId",
                table: "Admins",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_SetorId",
                table: "Departamentos",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosFerias_AdminId",
                table: "PedidosFerias",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosFerias_FuncionarioId",
                table: "PedidosFerias",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosFerias");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
