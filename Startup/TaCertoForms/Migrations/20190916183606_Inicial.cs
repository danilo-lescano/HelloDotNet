using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaCertoForms.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaCertoForms");

            migrationBuilder.CreateTable(
                name: "Atividade",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdAtividade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurmaDisciplinaProfessor = table.Column<int>(nullable: false),
                    DataInicio = table.Column<string>(nullable: true),
                    DataFim = table.Column<string>(nullable: true),
                    NumeroTentativas = table.Column<int>(nullable: false),
                    IsAleatorio = table.Column<bool>(nullable: false),
                    IsProva = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.IdAtividade);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeRespostaAluno",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_AtividadeRespostaAluno", x => x.IdAtividadeRespostaAluno);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.IdDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessor",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdDisciplinaProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDisciplina = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessor", x => x.IdDisciplinaProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Instituicao", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Licenca",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Licenca", x => x.IdLicenca);
                });

            migrationBuilder.CreateTable(
                name: "LogLogin",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdLogLoggin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPessoa = table.Column<int>(nullable: false),
                    HoraAcesso = table.Column<string>(nullable: true),
                    Plataforma = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogLogin", x => x.IdLogLoggin);
                });

            migrationBuilder.CreateTable(
                name: "Midia",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Midia", x => x.IdMidia);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "TaCertoForms",
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
                name: "PerfilPessoa",
                schema: "TaCertoForms",
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
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituicao = table.Column<int>(nullable: false),
                    IdPessoaLicenca = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "PessoaLicenca",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_PessoaLicenca", x => x.IdPessoaLicenca);
                });

            migrationBuilder.CreateTable(
                name: "Questao",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Questao", x => x.IdQuestao);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoRespostaAluno",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdQuestaoRespostaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAtividadeRespostaAluno = table.Column<int>(nullable: false),
                    IdQuestao = table.Column<int>(nullable: false),
                    NumAcerto = table.Column<int>(nullable: false),
                    NumErro = table.Column<int>(nullable: false),
                    Nota = table.Column<float>(nullable: false),
                    Tempo = table.Column<string>(nullable: true),
                    JsonResposta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoRespostaAluno", x => x.IdQuestaoRespostaAluno);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuestao",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdTipoQuestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuestao", x => x.IdTipoQuestao);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                schema: "TaCertoForms",
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
                    table.PrimaryKey("PK_Turma", x => x.IdTurma);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdTurmaAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => x.IdTurmaAluno);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplinaProfessor",
                schema: "TaCertoForms",
                columns: table => new
                {
                    IdTurmaDisciplinaProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdDisciplinaProfessor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplinaProfessor", x => x.IdTurmaDisciplinaProfessor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "AtividadeRespostaAluno",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Disciplina",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "DisciplinaProfessor",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Instituicao",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Licenca",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "LogLogin",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Midia",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "PerfilPessoa",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "PessoaLicenca",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Questao",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "QuestaoRespostaAluno",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "TipoQuestao",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "Turma",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "TurmaAluno",
                schema: "TaCertoForms");

            migrationBuilder.DropTable(
                name: "TurmaDisciplinaProfessor",
                schema: "TaCertoForms");
        }
    }
}
