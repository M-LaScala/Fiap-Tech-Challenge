using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tech.Challenge.Grupo27.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenomenandoCampoTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                schema: "techchanllenge",
                table: "Tb_Contato",
                newName: "NumeroTelefone");           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.RenameColumn(
                name: "NumeroTelefone",
                schema: "techchanllenge",
                table: "Tb_Contato",
                newName: "Telefone");           
        }
    }
}
