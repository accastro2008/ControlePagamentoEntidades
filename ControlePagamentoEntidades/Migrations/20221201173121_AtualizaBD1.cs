using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePagamentoEntidades.Migrations
{
    public partial class AtualizaBD1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    ProcessoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessoNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessoValorTotal = table.Column<double>(type: "float", nullable: false),
                    EntidadeModelEntidadeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.ProcessoID);
                    table.ForeignKey(
                        name: "FK_Processos_Entidades_EntidadeModelEntidadeID",
                        column: x => x.EntidadeModelEntidadeID,
                        principalTable: "Entidades",
                        principalColumn: "EntidadeID");
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagamentoSeq = table.Column<int>(type: "int", nullable: false),
                    PagamentoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PagamentoValor = table.Column<double>(type: "float", nullable: false),
                    ProcessoModelProcessoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoID);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Processos_ProcessoModelProcessoID",
                        column: x => x.ProcessoModelProcessoID,
                        principalTable: "Processos",
                        principalColumn: "ProcessoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ProcessoModelProcessoID",
                table: "Pagamentos",
                column: "ProcessoModelProcessoID");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_EntidadeModelEntidadeID",
                table: "Processos",
                column: "EntidadeModelEntidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
