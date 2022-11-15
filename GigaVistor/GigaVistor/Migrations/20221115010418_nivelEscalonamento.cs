using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaVistor.Migrations
{
    public partial class nivelEscalonamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelEscalonamento",
                table: "naoConformidades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelEscalonamento",
                table: "naoConformidades");
        }
    }
}
