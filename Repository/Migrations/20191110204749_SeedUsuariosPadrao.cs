using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class SeedUsuariosPadrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_ImpedimentosDefinitivos_IdImpedimentosDefinitivos",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_ImpedimentosTemporarios_IdImpedimentosTemporarios",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_TriagensClinicas_IdTriagemClinica",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_TriagensLaboratoriais_IdTriagemLaboratorial",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdImpedimentosDefinitivos",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdImpedimentosTemporarios",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdTriagemClinica",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdTriagemLaboratorial",
                table: "Doacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Triadores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Triadores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Triadores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Solicitantes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Solicitantes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Solicitantes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Solicitantes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Tatuagem",
                table: "ImpedimentosTemporarios",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gripe",
                table: "ImpedimentosTemporarios",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gravidez",
                table: "ImpedimentosTemporarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BebidaAlcoolica",
                table: "ImpedimentosTemporarios",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Doadores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Doadores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdTriagemLaboratorial",
                table: "Doacoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdTriagemClinica",
                table: "Doacoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdImpedimentosTemporarios",
                table: "Doacoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdImpedimentosDefinitivos",
                table: "Doacoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Solicitantes",
                columns: new[] { "IdSolicitante", "Cnpj", "RazaoSocial", "Responsavel", "Senha", "StatusUsuario" },
                values: new object[,]
                {
                    { 1, "11111111111111", "Solicitante 1", "Responsavel 1", "senhasolicitante", 1 },
                    { 2, "12345678901234", "Solicitante 2", "Responsavel 2", "senhasolicitante", 1 },
                    { 3, "33333333333333", "Solicitante 3", "Responsavel 3", "senhasolicitante", 0 }
                });

            migrationBuilder.InsertData(
                table: "Triadores",
                columns: new[] { "IdTriador", "Matricula", "NomeCompleto", "Senha", "StatusUsuario" },
                values: new object[,]
                {
                    { 1, "1111111", "Triador 1", "senhatriador", 1 },
                    { 2, "1234567", "Triador 2", "senhatriador", 1 },
                    { 3, "3333333", "Triador 3", "senhatriador", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdImpedimentosDefinitivos",
                table: "Doacoes",
                column: "IdImpedimentosDefinitivos",
                unique: true,
                filter: "[IdImpedimentosDefinitivos] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdImpedimentosTemporarios",
                table: "Doacoes",
                column: "IdImpedimentosTemporarios",
                unique: true,
                filter: "[IdImpedimentosTemporarios] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdTriagemClinica",
                table: "Doacoes",
                column: "IdTriagemClinica",
                unique: true,
                filter: "[IdTriagemClinica] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdTriagemLaboratorial",
                table: "Doacoes",
                column: "IdTriagemLaboratorial",
                unique: true,
                filter: "[IdTriagemLaboratorial] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_ImpedimentosDefinitivos_IdImpedimentosDefinitivos",
                table: "Doacoes",
                column: "IdImpedimentosDefinitivos",
                principalTable: "ImpedimentosDefinitivos",
                principalColumn: "IdImpedimentosDefinitivos",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_ImpedimentosTemporarios_IdImpedimentosTemporarios",
                table: "Doacoes",
                column: "IdImpedimentosTemporarios",
                principalTable: "ImpedimentosTemporarios",
                principalColumn: "IdImpedimentosTemporarios",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_TriagensClinicas_IdTriagemClinica",
                table: "Doacoes",
                column: "IdTriagemClinica",
                principalTable: "TriagensClinicas",
                principalColumn: "IdTriagemClinica",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_TriagensLaboratoriais_IdTriagemLaboratorial",
                table: "Doacoes",
                column: "IdTriagemLaboratorial",
                principalTable: "TriagensLaboratoriais",
                principalColumn: "IdTriagemLaboratorial",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_ImpedimentosDefinitivos_IdImpedimentosDefinitivos",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_ImpedimentosTemporarios_IdImpedimentosTemporarios",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_TriagensClinicas_IdTriagemClinica",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_TriagensLaboratoriais_IdTriagemLaboratorial",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdImpedimentosDefinitivos",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdImpedimentosTemporarios",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdTriagemClinica",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_IdTriagemLaboratorial",
                table: "Doacoes");

            migrationBuilder.DeleteData(
                table: "Solicitantes",
                keyColumn: "IdSolicitante",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Solicitantes",
                keyColumn: "IdSolicitante",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Solicitantes",
                keyColumn: "IdSolicitante",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Triadores",
                keyColumn: "IdTriador",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Triadores",
                keyColumn: "IdTriador",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Triadores",
                keyColumn: "IdTriador",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Triadores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Triadores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Triadores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Solicitantes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Solicitantes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Solicitantes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Solicitantes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "Tatuagem",
                table: "ImpedimentosTemporarios",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "Gripe",
                table: "ImpedimentosTemporarios",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Gravidez",
                table: "ImpedimentosTemporarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "BebidaAlcoolica",
                table: "ImpedimentosTemporarios",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Doadores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Doadores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "IdTriagemLaboratorial",
                table: "Doacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdTriagemClinica",
                table: "Doacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdImpedimentosTemporarios",
                table: "Doacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdImpedimentosDefinitivos",
                table: "Doacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdImpedimentosDefinitivos",
                table: "Doacoes",
                column: "IdImpedimentosDefinitivos",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdImpedimentosTemporarios",
                table: "Doacoes",
                column: "IdImpedimentosTemporarios",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdTriagemClinica",
                table: "Doacoes",
                column: "IdTriagemClinica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_IdTriagemLaboratorial",
                table: "Doacoes",
                column: "IdTriagemLaboratorial",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_ImpedimentosDefinitivos_IdImpedimentosDefinitivos",
                table: "Doacoes",
                column: "IdImpedimentosDefinitivos",
                principalTable: "ImpedimentosDefinitivos",
                principalColumn: "IdImpedimentosDefinitivos",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_ImpedimentosTemporarios_IdImpedimentosTemporarios",
                table: "Doacoes",
                column: "IdImpedimentosTemporarios",
                principalTable: "ImpedimentosTemporarios",
                principalColumn: "IdImpedimentosTemporarios",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_TriagensClinicas_IdTriagemClinica",
                table: "Doacoes",
                column: "IdTriagemClinica",
                principalTable: "TriagensClinicas",
                principalColumn: "IdTriagemClinica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_TriagensLaboratoriais_IdTriagemLaboratorial",
                table: "Doacoes",
                column: "IdTriagemLaboratorial",
                principalTable: "TriagensLaboratoriais",
                principalColumn: "IdTriagemLaboratorial",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
