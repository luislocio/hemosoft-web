using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repository.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doadores",
                columns: table => new
                {
                    IdDoador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<int>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    FatorRh = table.Column<int>(nullable: true),
                    TipoSanguineo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doadores", x => x.IdDoador);
                });

            migrationBuilder.CreateTable(
                name: "ImpedimentosDefinitivos",
                columns: table => new
                {
                    IdImpedimentosDefinitivos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AntecedenteAvc = table.Column<bool>(nullable: true),
                    HepatiteB = table.Column<bool>(nullable: true),
                    HepatiteC = table.Column<bool>(nullable: true),
                    Hiv = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpedimentosDefinitivos", x => x.IdImpedimentosDefinitivos);
                });

            migrationBuilder.CreateTable(
                name: "ImpedimentosTemporarios",
                columns: table => new
                {
                    IdImpedimentosTemporarios = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BebidaAlcoolica = table.Column<bool>(nullable: true),
                    BebidaAlcoolicaUltimaVez = table.Column<int>(nullable: true),
                    Gravidez = table.Column<int>(nullable: true),
                    GravidezUltimaVez = table.Column<int>(nullable: true),
                    Gripe = table.Column<bool>(nullable: true),
                    GripeUltimaVez = table.Column<int>(nullable: true),
                    Tatuagem = table.Column<bool>(nullable: true),
                    TatuagemUltimaVez = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpedimentosTemporarios", x => x.IdImpedimentosTemporarios);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    IdSolicitante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Responsavel = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    StatusUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.IdSolicitante);
                });

            migrationBuilder.CreateTable(
                name: "Triadores",
                columns: table => new
                {
                    IdTriador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: true),
                    NomeCompleto = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    StatusUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triadores", x => x.IdTriador);
                });

            migrationBuilder.CreateTable(
                name: "TriagensClinicas",
                columns: table => new
                {
                    IdTriagemClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Peso = table.Column<double>(nullable: false),
                    Pulso = table.Column<int>(nullable: false),
                    StatusTriagem = table.Column<int>(nullable: false),
                    Temperatura = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriagensClinicas", x => x.IdTriagemClinica);
                });

            migrationBuilder.CreateTable(
                name: "TriagensLaboratoriais",
                columns: table => new
                {
                    IdTriagemLaboratorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HepatiteB = table.Column<bool>(nullable: true),
                    HepatiteC = table.Column<bool>(nullable: true),
                    Hiv = table.Column<bool>(nullable: true),
                    StatusTriagem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriagensLaboratoriais", x => x.IdTriagemLaboratorial);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    IdSolicitacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    SolicitanteIdSolicitante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.IdSolicitacao);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Solicitantes_SolicitanteIdSolicitante",
                        column: x => x.SolicitanteIdSolicitante,
                        principalTable: "Solicitantes",
                        principalColumn: "IdSolicitante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    IdDoacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataDoacao = table.Column<DateTime>(nullable: false),
                    StatusDoacao = table.Column<int>(nullable: false),
                    DoadorIdDoador = table.Column<int>(nullable: true),
                    TriadorIdTriador = table.Column<int>(nullable: true),
                    SolicitacaoIdSolicitacao = table.Column<int>(nullable: true),
                    IdTriagemClinica = table.Column<int>(nullable: false),
                    IdTriagemLaboratorial = table.Column<int>(nullable: false),
                    IdImpedimentosTemporarios = table.Column<int>(nullable: false),
                    IdImpedimentosDefinitivos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.IdDoacao);
                    table.ForeignKey(
                        name: "FK_Doacoes_Doadores_DoadorIdDoador",
                        column: x => x.DoadorIdDoador,
                        principalTable: "Doadores",
                        principalColumn: "IdDoador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doacoes_ImpedimentosDefinitivos_IdImpedimentosDefinitivos",
                        column: x => x.IdImpedimentosDefinitivos,
                        principalTable: "ImpedimentosDefinitivos",
                        principalColumn: "IdImpedimentosDefinitivos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_ImpedimentosTemporarios_IdImpedimentosTemporarios",
                        column: x => x.IdImpedimentosTemporarios,
                        principalTable: "ImpedimentosTemporarios",
                        principalColumn: "IdImpedimentosTemporarios",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_TriagensClinicas_IdTriagemClinica",
                        column: x => x.IdTriagemClinica,
                        principalTable: "TriagensClinicas",
                        principalColumn: "IdTriagemClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_TriagensLaboratoriais_IdTriagemLaboratorial",
                        column: x => x.IdTriagemLaboratorial,
                        principalTable: "TriagensLaboratoriais",
                        principalColumn: "IdTriagemLaboratorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_Solicitacoes_SolicitacaoIdSolicitacao",
                        column: x => x.SolicitacaoIdSolicitacao,
                        principalTable: "Solicitacoes",
                        principalColumn: "IdSolicitacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doacoes_Triadores_TriadorIdTriador",
                        column: x => x.TriadorIdTriador,
                        principalTable: "Triadores",
                        principalColumn: "IdTriador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_DoadorIdDoador",
                table: "Doacoes",
                column: "DoadorIdDoador");

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

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_SolicitacaoIdSolicitacao",
                table: "Doacoes",
                column: "SolicitacaoIdSolicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_TriadorIdTriador",
                table: "Doacoes",
                column: "TriadorIdTriador");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_SolicitanteIdSolicitante",
                table: "Solicitacoes",
                column: "SolicitanteIdSolicitante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "Doadores");

            migrationBuilder.DropTable(
                name: "ImpedimentosDefinitivos");

            migrationBuilder.DropTable(
                name: "ImpedimentosTemporarios");

            migrationBuilder.DropTable(
                name: "TriagensClinicas");

            migrationBuilder.DropTable(
                name: "TriagensLaboratoriais");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Triadores");

            migrationBuilder.DropTable(
                name: "Solicitantes");
        }
    }
}