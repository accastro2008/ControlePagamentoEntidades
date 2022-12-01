using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePagamentoEntidades.Migrations
{
    public partial class AtualizaBD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessoSituacao",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessoSituacao",
                table: "Processos");
        }
    }
}
