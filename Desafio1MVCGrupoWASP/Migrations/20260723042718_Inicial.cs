using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Desafio1MVCGrupoWASP.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaContratacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empleado_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Área de RRHH", "Recursos Humanos" },
                    { 2, "Área de TI", "Tecnología" },
                    { 3, "Área comercial", "Ventas" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "ID", "DepartamentoId", "Descripcion", "FechaContratacion", "FechaNacimiento", "Nombre", "Salario" },
                values: new object[,]
                {
                    { 1, 1, null, new DateOnly(2010, 8, 15), new DateOnly(1985, 5, 20), "John Doe", 50000m },
                    { 2, 2, null, new DateOnly(2015, 1, 25), new DateOnly(1990, 3, 10), "Jane Smith", 70000m },
                    { 3, 3, null, new DateOnly(2012, 6, 18), new DateOnly(1982, 11, 22), "Mark Johnson", 55000m },
                    { 4, 1, null, new DateOnly(2005, 10, 12), new DateOnly(1978, 7, 30), "Emily Davis", 75000m },
                    { 5, 2, null, new DateOnly(2020, 4, 15), new DateOnly(1995, 12, 5), "Michael Brown", 60000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
