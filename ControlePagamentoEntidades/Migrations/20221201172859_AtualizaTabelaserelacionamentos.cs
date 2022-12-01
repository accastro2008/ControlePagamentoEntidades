using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePagamentoEntidades.Migrations
{
    public partial class AtualizaTabelaserelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Endidades",
                table: "Endidades");

            migrationBuilder.RenameTable(
                name: "Endidades",
                newName: "Entidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades",
                column: "EntidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades");

            migrationBuilder.RenameTable(
                name: "Entidades",
                newName: "Endidades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endidades",
                table: "Endidades",
                column: "EntidadeID");
        }
    }
}
