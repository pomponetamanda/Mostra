using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mostra.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cadastro",
                table: "cadastro");

            migrationBuilder.RenameTable(
                name: "cadastro",
                newName: "clientes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "clientes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "clientes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "clientes",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "cpf",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "clientes",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "senha",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "telefone",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "cadastro");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "cadastro",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "cadastro",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cadastro",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cadastro",
                table: "cadastro",
                column: "Id");
        }
    }
}
