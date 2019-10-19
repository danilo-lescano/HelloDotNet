using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaCertoForms.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadeRespostaAlunos",
                columns: table => new
                {
                    IdAtividadeRespostaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAtividade = table.Column<int>(nullable: false),
                    IdAluno = table.Column<int>(nullable: false),
                    DataEnvio = table.Column<string>(nullable: true),
                    Nota = table.Column<float>(nullable: false),
                    TempoTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeRespostaAlunos", x => x.IdAtividadeRespostaAluno);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    IdAtividade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurmaDisciplinaProfessor = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    NumeroTentativas = table.Column<int>(nullable: false),
                    IsAleatorio = table.Column<bool>(nullable: false),
                    IsProva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.IdAtividade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.IdDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaTurmas",
                columns: table => new
                {
                    IdDisciplinaTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDisciplina = table.Column<int>(nullable: false),
                    IdTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaTurmas", x => x.IdDisciplinaTurma);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pais = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Instituicaos",
                columns: table => new
                {
                    IdInstituicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    IdEnderecoPrincipal = table.Column<int>(nullable: false),
                    IdEnderecoCobranca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicaos", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    IdLicenca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    NumeroDeLinceca = table.Column<int>(nullable: false),
                    ValidadeLicenca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.IdLicenca);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Questaos",
                columns: table => new
                {
                    IdQuestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAtividade = table.Column<int>(nullable: false),
                    IdTipoQuestao = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Enunciado = table.Column<string>(nullable: true),
                    JsonQuestao = table.Column<string>(nullable: true),
                    PesoNota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questaos", x => x.IdQuestao);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAlunos",
                columns: table => new
                {
                    IdTurmaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAlunos", x => x.IdTurmaAluno);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinaProfessors",
                columns: table => new
                {
                    IdTurmaDisciplinaProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProfessor = table.Column<int>(nullable: false),
                    IdDisciplinaTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinaProfessors", x => x.IdTurmaDisciplinaProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    Periodo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    PerfilIdPerfil = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_Perfil_PerfilIdPerfil",
                        column: x => x.PerfilIdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPessoa",
                columns: table => new
                {
                    IdPerfilPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPerfil = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPessoa", x => x.IdPerfilPessoa);
                    table.ForeignKey(
                        name: "FK_PerfilPessoa_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilPessoa_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPessoa_IdPerfil",
                table: "PerfilPessoa",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPessoa_IdPessoa",
                table: "PerfilPessoa",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_PerfilIdPerfil",
                table: "Pessoas",
                column: "PerfilIdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeRespostaAlunos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "DisciplinaTurmas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Instituicaos");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "PerfilPessoa");

            migrationBuilder.DropTable(
                name: "Questaos");

            migrationBuilder.DropTable(
                name: "TurmaAlunos");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinaProfessors");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
