using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaVistor.Migrations
{
    public partial class itemChecklistTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemCheckListTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCheckList = table.Column<long>(type: "bigint", nullable: false),
                    DateCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriador = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCheckListTemplates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemCheckListTemplates");
        }
    }
}
