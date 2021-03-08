using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salao.Data.Migrations
{
    public partial class AddCampoDataTerminoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataTermino",
                table: "Agendamentos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTermino",
                table: "Agendamentos");
        }
    }
}
