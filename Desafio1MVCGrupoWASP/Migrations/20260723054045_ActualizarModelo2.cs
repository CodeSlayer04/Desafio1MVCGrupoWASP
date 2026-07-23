using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio1MVCGrupoWASP.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModelo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "Encargado de gestión del talento humano.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "Desarrolladora de software.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "Ejecutivo de ventas.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Gerente de Recursos Humanos.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Analista de infraestructura tecnológica.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 1,
                column: "Descripcion",
                value: "Especialista en reclutamiento y gestión del talento humano.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 2,
                column: "Descripcion",
                value: "Desarrolladora de software encargada del mantenimiento de aplicaciones.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 3,
                column: "Descripcion",
                value: "Ejecutivo de ventas responsable de la atención a clientes corporativos.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 4,
                column: "Descripcion",
                value: "Gerente de Recursos Humanos encargada de la administración del personal.");

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "ID",
                keyValue: 5,
                column: "Descripcion",
                value: "Analista de infraestructura tecnológica y soporte a usuarios.");
        }
    }
}
