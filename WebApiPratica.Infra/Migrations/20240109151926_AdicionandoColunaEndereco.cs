using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPratica.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");
        }
    }
}
