using Microsoft.EntityFrameworkCore.Migrations;

namespace GlobalPessoas.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CPF",
                table: "Pessoa",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Pessoa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
