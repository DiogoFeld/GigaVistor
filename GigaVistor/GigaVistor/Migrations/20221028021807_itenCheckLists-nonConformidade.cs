using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaVistor.Migrations
{
    public partial class itenCheckListsnonConformidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itensCheckList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aderente = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Escalonado = table.Column<bool>(type: "bit", nullable: false),
                    ExplicacaoNaoConformidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaoConformidade = table.Column<bool>(type: "bit", nullable: false),
                    NivelNaoConformidade = table.Column<int>(type: "int", nullable: false),
                    DateCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePrazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePrazoEscalonado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusPosEscalonado = table.Column<int>(type: "int", nullable: false),
                    IdCriador = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsavel = table.Column<long>(type: "bigint", nullable: false),
                    IdCheckList = table.Column<long>(type: "bigint", nullable: false),
                    IdNaoConformidade = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itensCheckList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "naoConformidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCriador = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explicação = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classificao = table.Column<int>(type: "int", nullable: false),
                    PrazoResolucao = table.Column<int>(type: "int", nullable: false),
                    Aderente = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusPosEscalonamento = table.Column<int>(type: "int", nullable: false),
                    DatePrazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrazoCumprido = table.Column<bool>(type: "bit", nullable: false),
                    DatePrazoEscalonado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrazoEscalonadoCumprido = table.Column<bool>(type: "bit", nullable: false),
                    IdEscalonamentoResponsavel = table.Column<int>(type: "int", nullable: false),
                    StatusPosEscalonado = table.Column<int>(type: "int", nullable: false),
                    IdEscalonamento = table.Column<long>(type: "bigint", nullable: false),
                    IdResponsavel = table.Column<long>(type: "bigint", nullable: false),
                    IdCheckList = table.Column<long>(type: "bigint", nullable: false),
                    IdTarefa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_naoConformidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itensCheckList");

            migrationBuilder.DropTable(
                name: "naoConformidades");
        }
    }
}
