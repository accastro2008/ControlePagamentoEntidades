using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePagamentoEntidades.Migrations
{
    public partial class CriaTabEntidadeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endidades",
                columns: table => new
                {
                    EntidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadeNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadeCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endidades", x => x.EntidadeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endidades");
        }
    }
}
