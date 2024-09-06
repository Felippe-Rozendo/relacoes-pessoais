using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace relacoespessoaisapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    CodPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.CodPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    CodContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContato = table.Column<int>(type: "int", nullable: false),
                    ValorContato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.CodContato);
                    table.ForeignKey(
                        name: "FK_Contatos_Pessoas_CodPessoa",
                        column: x => x.CodPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "CodPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_CodPessoa",
                table: "Contatos",
                column: "CodPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
