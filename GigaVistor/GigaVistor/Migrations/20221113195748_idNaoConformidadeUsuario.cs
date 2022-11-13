using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaVistor.Migrations
{
    public partial class idNaoConformidadeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdNaoConformidadeResponsavel",
                table: "itensCheckList",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNaoConformidadeResponsavel",
                table: "itensCheckList");
        }
    }
}
