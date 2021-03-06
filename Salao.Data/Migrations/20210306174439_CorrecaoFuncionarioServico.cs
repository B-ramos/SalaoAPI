using Microsoft.EntityFrameworkCore.Migrations;

namespace Salao.Data.Migrations
{
    public partial class CorrecaoFuncionarioServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosServicos_Servicos_FuncionarioId",
                table: "FuncionariosServicos");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosServicos_ServicoId",
                table: "FuncionariosServicos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosServicos_Servicos_ServicoId",
                table: "FuncionariosServicos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosServicos_Servicos_ServicoId",
                table: "FuncionariosServicos");

            migrationBuilder.DropIndex(
                name: "IX_FuncionariosServicos_ServicoId",
                table: "FuncionariosServicos");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosServicos_Servicos_FuncionarioId",
                table: "FuncionariosServicos",
                column: "FuncionarioId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
