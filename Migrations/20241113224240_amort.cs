using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Camiones.Migrations
{
    /// <inheritdoc />
    public partial class amort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Amortizado",
                table: "Viajes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amortizado",
                table: "Viajes");
        }
    }
}
