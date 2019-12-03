using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class NullableTipoSanguineoFatorRh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoSanguineo",
                table: "Doadores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FatorRh",
                table: "Doadores",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoSanguineo",
                table: "Doadores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FatorRh",
                table: "Doadores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}