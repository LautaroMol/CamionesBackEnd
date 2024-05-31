using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Camiones.Migrations
{
    /// <inheritdoc />
    public partial class Correcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubtotalString",
                table: "Cargas");

            migrationBuilder.AlterColumn<bool>(
                name: "Borrado",
                table: "Cargas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Borrado",
                table: "Cargas",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "SubtotalString",
                table: "Cargas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
