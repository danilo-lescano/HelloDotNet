using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaCertoForms.Migrations
{
    public partial class Iteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaCerto");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                schema: "TaCerto",
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
                name: "Enderecos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pais = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Midias",
                schema: "TaCerto",
                columns: table => new
                {
                    IdMidia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEntidade = table.Column<int>(nullable: false),
                    TipoEntidade = table.Column<string>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Extensao = table.Column<string>(nullable: true),
                    Caminho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midias", x => x.IdMidia);
                });

            migrationBuilder.CreateTable(
                name: "Perfils",
                schema: "TaCerto",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuestaos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdTipoQuestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuestaos", x => x.IdTipoQuestao);
                });

            migrationBuilder.CreateTable(
                name: "Instituicaos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdInstituicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEnderecoPrincipal = table.Column<int>(nullable: false),
                    IdEnderecoCobranca = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicaos", x => x.IdInstituicao);
                    table.ForeignKey(
                        name: "FK_Instituicaos_Enderecos_IdEnderecoCobranca",
                        column: x => x.IdEnderecoCobranca,
                        principalSchema: "TaCerto",
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instituicaos_Enderecos_IdEnderecoPrincipal",
                        column: x => x.IdEnderecoPrincipal,
                        principalSchema: "TaCerto",
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                schema: "TaCerto",
                columns: table => new
                {
                    IdLicenca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    NumeroDeLinceca = table.Column<int>(nullable: false),
                    InicioLicenca = table.Column<DateTime>(nullable: false),
                    ValidadeLicenca = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.IdLicenca);
                    table.ForeignKey(
                        name: "FK_Licencas_Instituicaos_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalSchema: "TaCerto",
                        principalTable: "Instituicaos",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                schema: "TaCerto",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_Instituicaos_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalSchema: "TaCerto",
                        principalTable: "Instituicaos",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                schema: "TaCerto",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    Periodo = table.Column<string>(nullable: true),
                    Ano = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK_Turmas_Instituicaos_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalSchema: "TaCerto",
                        principalTable: "Instituicaos",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessors",
                schema: "TaCerto",
                columns: table => new
                {
                    IdDisciplinaProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDisciplina = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessors", x => x.IdDisciplinaProfessor);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessors_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalSchema: "TaCerto",
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessors_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogLogins",
                schema: "TaCerto",
                columns: table => new
                {
                    IdLogLoggin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPessoa = table.Column<int>(nullable: false),
                    HoraAcesso = table.Column<DateTime>(nullable: false),
                    Plataforma = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLogins", x => x.IdLogLoggin);
                    table.ForeignKey(
                        name: "FK_LogLogins_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPessoas",
                schema: "TaCerto",
                columns: table => new
                {
                    IdPerfilPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPerfil = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPessoas", x => x.IdPerfilPessoa);
                    table.ForeignKey(
                        name: "FK_PerfilPessoas_Perfils_IdPerfil",
                        column: x => x.IdPerfil,
                        principalSchema: "TaCerto",
                        principalTable: "Perfils",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilPessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaLicencas",
                schema: "TaCerto",
                columns: table => new
                {
                    IdPessoaLicenca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPessoa = table.Column<int>(nullable: false),
                    IdLicenca = table.Column<int>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaLicencas", x => x.IdPessoaLicenca);
                    table.ForeignKey(
                        name: "FK_PessoaLicencas_Licencas_IdLicenca",
                        column: x => x.IdLicenca,
                        principalSchema: "TaCerto",
                        principalTable: "Licencas",
                        principalColumn: "IdLicenca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaLicencas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAlunos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdTurmaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdAluno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAlunos", x => x.IdTurmaAluno);
                    table.ForeignKey(
                        name: "FK_TurmaAlunos_Pessoas_IdAluno",
                        column: x => x.IdAluno,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAlunos_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalSchema: "TaCerto",
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinaProfessors",
                schema: "TaCerto",
                columns: table => new
                {
                    IdTurmaDisciplinaProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdDisciplinaProfessor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinaProfessors", x => x.IdTurmaDisciplinaProfessor);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinaProfessors_DisciplinaProfessors_IdDisciplinaProfessor",
                        column: x => x.IdDisciplinaProfessor,
                        principalSchema: "TaCerto",
                        principalTable: "DisciplinaProfessors",
                        principalColumn: "IdDisciplinaProfessor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplinaProfessors_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalSchema: "TaCerto",
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                schema: "TaCerto",
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
                    table.ForeignKey(
                        name: "FK_Atividades_TurmaDisciplinaProfessors_IdTurmaDisciplinaProfessor",
                        column: x => x.IdTurmaDisciplinaProfessor,
                        principalSchema: "TaCerto",
                        principalTable: "TurmaDisciplinaProfessors",
                        principalColumn: "IdTurmaDisciplinaProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeRespostaAlunos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdAtividadeRespostaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAtividade = table.Column<int>(nullable: false),
                    IdAluno = table.Column<int>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<float>(nullable: false),
                    TempoTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeRespostaAlunos", x => x.IdAtividadeRespostaAluno);
                    table.ForeignKey(
                        name: "FK_AtividadeRespostaAlunos_Pessoas_IdAluno",
                        column: x => x.IdAluno,
                        principalSchema: "TaCerto",
                        principalTable: "Pessoas",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeRespostaAlunos_Atividades_IdAtividade",
                        column: x => x.IdAtividade,
                        principalSchema: "TaCerto",
                        principalTable: "Atividades",
                        principalColumn: "IdAtividade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questaos",
                schema: "TaCerto",
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
                    table.ForeignKey(
                        name: "FK_Questaos_Atividades_IdAtividade",
                        column: x => x.IdAtividade,
                        principalSchema: "TaCerto",
                        principalTable: "Atividades",
                        principalColumn: "IdAtividade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questaos_TipoQuestaos_IdTipoQuestao",
                        column: x => x.IdTipoQuestao,
                        principalSchema: "TaCerto",
                        principalTable: "TipoQuestaos",
                        principalColumn: "IdTipoQuestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoRespostaAlunos",
                schema: "TaCerto",
                columns: table => new
                {
                    IdQuestaoRespostaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAtividadeRespostaAluno = table.Column<int>(nullable: false),
                    IdQuestao = table.Column<int>(nullable: false),
                    NumAcerto = table.Column<int>(nullable: false),
                    NumErro = table.Column<int>(nullable: false),
                    Nota = table.Column<float>(nullable: false),
                    TempoEmMilisegundos = table.Column<int>(nullable: false),
                    JsonResposta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoRespostaAlunos", x => x.IdQuestaoRespostaAluno);
                    table.ForeignKey(
                        name: "FK_QuestaoRespostaAlunos_AtividadeRespostaAlunos_IdAtividadeRespostaAluno",
                        column: x => x.IdAtividadeRespostaAluno,
                        principalSchema: "TaCerto",
                        principalTable: "AtividadeRespostaAlunos",
                        principalColumn: "IdAtividadeRespostaAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoRespostaAlunos_Questaos_IdQuestao",
                        column: x => x.IdQuestao,
                        principalSchema: "TaCerto",
                        principalTable: "Questaos",
                        principalColumn: "IdQuestao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostaAlunos_IdAluno",
                schema: "TaCerto",
                table: "AtividadeRespostaAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostaAlunos_IdAtividade",
                schema: "TaCerto",
                table: "AtividadeRespostaAlunos",
                column: "IdAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdTurmaDisciplinaProfessor",
                schema: "TaCerto",
                table: "Atividades",
                column: "IdTurmaDisciplinaProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessors_IdDisciplina",
                schema: "TaCerto",
                table: "DisciplinaProfessors",
                column: "IdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessors_IdPessoa",
                schema: "TaCerto",
                table: "DisciplinaProfessors",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicaos_IdEnderecoCobranca",
                schema: "TaCerto",
                table: "Instituicaos",
                column: "IdEnderecoCobranca");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicaos_IdEnderecoPrincipal",
                schema: "TaCerto",
                table: "Instituicaos",
                column: "IdEnderecoPrincipal");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_IdInstituicao",
                schema: "TaCerto",
                table: "Licencas",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_LogLogins_IdPessoa",
                schema: "TaCerto",
                table: "LogLogins",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPessoas_IdPerfil",
                schema: "TaCerto",
                table: "PerfilPessoas",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPessoas_IdPessoa",
                schema: "TaCerto",
                table: "PerfilPessoas",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaLicencas_IdLicenca",
                schema: "TaCerto",
                table: "PessoaLicencas",
                column: "IdLicenca");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaLicencas_IdPessoa",
                schema: "TaCerto",
                table: "PessoaLicencas",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_IdInstituicao",
                schema: "TaCerto",
                table: "Pessoas",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoRespostaAlunos_IdAtividadeRespostaAluno",
                schema: "TaCerto",
                table: "QuestaoRespostaAlunos",
                column: "IdAtividadeRespostaAluno");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoRespostaAlunos_IdQuestao",
                schema: "TaCerto",
                table: "QuestaoRespostaAlunos",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_Questaos_IdAtividade",
                schema: "TaCerto",
                table: "Questaos",
                column: "IdAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_Questaos_IdTipoQuestao",
                schema: "TaCerto",
                table: "Questaos",
                column: "IdTipoQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAlunos_IdAluno",
                schema: "TaCerto",
                table: "TurmaAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAlunos_IdTurma",
                schema: "TaCerto",
                table: "TurmaAlunos",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinaProfessors_IdDisciplinaProfessor",
                schema: "TaCerto",
                table: "TurmaDisciplinaProfessors",
                column: "IdDisciplinaProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplinaProfessors_IdTurma",
                schema: "TaCerto",
                table: "TurmaDisciplinaProfessors",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdInstituicao",
                schema: "TaCerto",
                table: "Turmas",
                column: "IdInstituicao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogLogins",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Midias",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "PerfilPessoas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "PessoaLicencas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "QuestaoRespostaAlunos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "TurmaAlunos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Perfils",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Licencas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "AtividadeRespostaAlunos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Questaos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Atividades",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "TipoQuestaos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinaProfessors",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "DisciplinaProfessors",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Turmas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Disciplinas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Pessoas",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Instituicaos",
                schema: "TaCerto");

            migrationBuilder.DropTable(
                name: "Enderecos",
                schema: "TaCerto");
        }
    }
}
