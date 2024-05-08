using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech.Challenge.Grupo27.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "techchanllenge");

            migrationBuilder.CreateTable(
                name: "Tb_Contato",
                schema: "techchanllenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(80)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(40)", nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Ddd = table.Column<string>(type: "Varchar(2)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Contato", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Contato",
                schema: "techchanllenge");
        }
    }
}
