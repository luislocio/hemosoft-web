using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class NullableTriagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusTriagem",
                table: "TriagensLaboratoriais",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Hiv",
                table: "TriagensLaboratoriais",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "HepatiteC",
                table: "TriagensLaboratoriais",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "HepatiteB",
                table: "TriagensLaboratoriais",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusTriagem",
                table: "TriagensLaboratoriais",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Hiv",
                table: "TriagensLaboratoriais",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HepatiteC",
                table: "TriagensLaboratoriais",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HepatiteB",
                table: "TriagensLaboratoriais",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}