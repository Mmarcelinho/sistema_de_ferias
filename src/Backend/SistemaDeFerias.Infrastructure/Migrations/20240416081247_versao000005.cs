using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeFerias.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class versao000005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "DataCriacao", "Nome" },
                values: new object[] { 1L, new DateTime(2024, 4, 16, 8, 12, 43, 157, DateTimeKind.Utc).AddTicks(4088), "Setor1" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "DataCriacao", "Nome", "SetorId" },
                values: new object[] { 1L, new DateTime(2024, 4, 16, 8, 12, 43, 141, DateTimeKind.Utc).AddTicks(2982), "Departamento1", 1L });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Administrador", "Cargo", "DataCriacao", "DepartamentoId", "Email", "Nome", "Senha", "Telefone" },
                values: new object[] { 1L, true, "Gerente Geral", new DateTime(2024, 4, 16, 8, 12, 43, 138, DateTimeKind.Utc).AddTicks(6263), 1L, "admin@empresa.com", "Admin Principal", "ce333f1a30e5c9f4767b545a8750afa23f2f4d9c24ca5a2bef40607fea9133d466cb640e06d110341d558feefeccc4bdb7c25c3454c3af993dbd0ab7ffffb396", "71 9 9999-9999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
