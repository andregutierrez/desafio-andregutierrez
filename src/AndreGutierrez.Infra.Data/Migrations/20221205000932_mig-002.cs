using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreGutierrez.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                schema: "dbo",
                table: "Pessoa",
                column: "CidadeId",
                principalSchema: "dbo",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cidade_CidadeId",
                schema: "dbo",
                table: "Pessoa",
                column: "CidadeId",
                principalSchema: "dbo",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
