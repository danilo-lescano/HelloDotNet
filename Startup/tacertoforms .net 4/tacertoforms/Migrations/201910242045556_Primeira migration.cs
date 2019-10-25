namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiramigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TaCerto.Atividade",
                c => new
                    {
                        IdAtividade = c.Int(nullable: false, identity: true),
                        IdTurmaDisciplinaAutor = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        NumeroTentativas = c.Int(nullable: false),
                        IsAleatorio = c.Boolean(nullable: false),
                        IsProva = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAtividade)
                .ForeignKey("TaCerto.TurmaDisciplinaAutor", t => t.IdTurmaDisciplinaAutor)
                .Index(t => t.IdTurmaDisciplinaAutor);
            
            CreateTable(
                "TaCerto.TurmaDisciplinaAutor",
                c => new
                    {
                        IdTurmaDisciplinaAutor = c.Int(nullable: false, identity: true),
                        IdAutor = c.Int(nullable: false),
                        IdDisciplinaTurma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTurmaDisciplinaAutor)
                .ForeignKey("TaCerto.Pessoa", t => t.IdAutor)
                .ForeignKey("TaCerto.DisciplinaTurma", t => t.IdDisciplinaTurma)
                .Index(t => t.IdAutor)
                .Index(t => t.IdDisciplinaTurma);
            
            CreateTable(
                "TaCerto.Pessoa",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false, identity: true),
                        IdInstituicao = c.Int(nullable: false),
                        Perfil = c.Int(nullable: false),
                        Nome = c.String(maxLength: 150),
                        CPF = c.String(maxLength: 14),
                        Email = c.String(maxLength: 150),
                        Senha = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("TaCerto.Instituicao", t => t.IdInstituicao)
                .Index(t => t.IdInstituicao);
            
            CreateTable(
                "TaCerto.Instituicao",
                c => new
                    {
                        IdInstituicao = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 150),
                        NomeFantasia = c.String(maxLength: 150),
                        CNPJ = c.String(maxLength: 18),
                        Email = c.String(maxLength: 150),
                        Telefone = c.String(maxLength: 25),
                        IdEnderecoPrincipal = c.Int(nullable: false),
                        IdEnderecoCobranca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdInstituicao)
                .ForeignKey("TaCerto.Endereco", t => t.IdEnderecoCobranca)
                .ForeignKey("TaCerto.Endereco", t => t.IdEnderecoPrincipal)
                .Index(t => t.IdEnderecoPrincipal)
                .Index(t => t.IdEnderecoCobranca);
            
            CreateTable(
                "TaCerto.Endereco",
                c => new
                    {
                        IdEndereco = c.Int(nullable: false, identity: true),
                        Pais = c.String(maxLength: 150),
                        UF = c.String(maxLength: 2),
                        Cidade = c.String(maxLength: 150),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 150),
                        CEP = c.String(maxLength: 10),
                        Logradouro = c.String(maxLength: 150),
                        Bairro = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.IdEndereco);
            
            CreateTable(
                "TaCerto.DisciplinaTurma",
                c => new
                    {
                        IdDisciplinaTurma = c.Int(nullable: false, identity: true),
                        IdDisciplina = c.Int(nullable: false),
                        IdTurma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDisciplinaTurma)
                .ForeignKey("TaCerto.Disciplina", t => t.IdDisciplina)
                .ForeignKey("TaCerto.Turma", t => t.IdTurma)
                .Index(t => t.IdDisciplina)
                .Index(t => t.IdTurma);
            
            CreateTable(
                "TaCerto.Disciplina",
                c => new
                    {
                        IdDisciplina = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150),
                        Descricao = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.IdDisciplina);
            
            CreateTable(
                "TaCerto.Turma",
                c => new
                    {
                        IdTurma = c.Int(nullable: false, identity: true),
                        IdInstituicao = c.Int(nullable: false),
                        Serie = c.String(),
                        Periodo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTurma)
                .ForeignKey("TaCerto.Instituicao", t => t.IdInstituicao)
                .Index(t => t.IdInstituicao);
            
            CreateTable(
                "TaCerto.Midia",
                c => new
                    {
                        IdMidia = c.Guid(nullable: false),
                        IdOrigem = c.Int(nullable: false),
                        Tabela = c.String(maxLength: 150),
                        Filename = c.String(maxLength: 150),
                        Link = c.String(maxLength: 150),
                        Extensao = c.String(maxLength: 150),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMidia);
            
            CreateTable(
                "TaCerto.Questao",
                c => new
                    {
                        IdQuestao = c.Int(nullable: false, identity: true),
                        IdAtividade = c.Int(nullable: false),
                        IdTipoQuestao = c.Int(nullable: false),
                        Titulo = c.String(),
                        Enunciado = c.String(),
                        JsonQuestao = c.String(),
                        PesoNota = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuestao)
                .ForeignKey("TaCerto.Atividade", t => t.IdAtividade)
                .ForeignKey("TaCerto.TipoQuestao", t => t.IdTipoQuestao)
                .Index(t => t.IdAtividade)
                .Index(t => t.IdTipoQuestao);
            
            CreateTable(
                "TaCerto.TipoQuestao",
                c => new
                    {
                        IdTipoQuestao = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.IdTipoQuestao);
            
            CreateTable(
                "TaCerto.TurmaAluno",
                c => new
                    {
                        IdTurmaAluno = c.Int(nullable: false, identity: true),
                        IdTurma = c.Int(nullable: false),
                        IdPessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTurmaAluno)
                .ForeignKey("TaCerto.Pessoa", t => t.IdPessoa)
                .ForeignKey("TaCerto.Turma", t => t.IdTurma)
                .Index(t => t.IdTurma)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "TaCerto.LogLogin",
                c => new
                    {
                        IdLogLoggin = c.Int(nullable: false, identity: true),
                        IdPessoa = c.Int(nullable: false),
                        HoraAcesso = c.DateTime(nullable: false),
                        Plataforma = c.String(maxLength: 150),
                        DeviceId = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.IdLogLoggin)
                .ForeignKey("TaCerto.Pessoa", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TaCerto.LogLogin", "IdPessoa", "TaCerto.Pessoa");
            DropForeignKey("TaCerto.TurmaAluno", "IdTurma", "TaCerto.Turma");
            DropForeignKey("TaCerto.TurmaAluno", "IdPessoa", "TaCerto.Pessoa");
            DropForeignKey("TaCerto.Questao", "IdTipoQuestao", "TaCerto.TipoQuestao");
            DropForeignKey("TaCerto.Questao", "IdAtividade", "TaCerto.Atividade");
            DropForeignKey("TaCerto.Atividade", "IdTurmaDisciplinaAutor", "TaCerto.TurmaDisciplinaAutor");
            DropForeignKey("TaCerto.TurmaDisciplinaAutor", "IdDisciplinaTurma", "TaCerto.DisciplinaTurma");
            DropForeignKey("TaCerto.DisciplinaTurma", "IdTurma", "TaCerto.Turma");
            DropForeignKey("TaCerto.Turma", "IdInstituicao", "TaCerto.Instituicao");
            DropForeignKey("TaCerto.DisciplinaTurma", "IdDisciplina", "TaCerto.Disciplina");
            DropForeignKey("TaCerto.TurmaDisciplinaAutor", "IdAutor", "TaCerto.Pessoa");
            DropForeignKey("TaCerto.Pessoa", "IdInstituicao", "TaCerto.Instituicao");
            DropForeignKey("TaCerto.Instituicao", "IdEnderecoPrincipal", "TaCerto.Endereco");
            DropForeignKey("TaCerto.Instituicao", "IdEnderecoCobranca", "TaCerto.Endereco");
            DropIndex("TaCerto.LogLogin", new[] { "IdPessoa" });
            DropIndex("TaCerto.TurmaAluno", new[] { "IdPessoa" });
            DropIndex("TaCerto.TurmaAluno", new[] { "IdTurma" });
            DropIndex("TaCerto.Questao", new[] { "IdTipoQuestao" });
            DropIndex("TaCerto.Questao", new[] { "IdAtividade" });
            DropIndex("TaCerto.Turma", new[] { "IdInstituicao" });
            DropIndex("TaCerto.DisciplinaTurma", new[] { "IdTurma" });
            DropIndex("TaCerto.DisciplinaTurma", new[] { "IdDisciplina" });
            DropIndex("TaCerto.Instituicao", new[] { "IdEnderecoCobranca" });
            DropIndex("TaCerto.Instituicao", new[] { "IdEnderecoPrincipal" });
            DropIndex("TaCerto.Pessoa", new[] { "IdInstituicao" });
            DropIndex("TaCerto.TurmaDisciplinaAutor", new[] { "IdDisciplinaTurma" });
            DropIndex("TaCerto.TurmaDisciplinaAutor", new[] { "IdAutor" });
            DropIndex("TaCerto.Atividade", new[] { "IdTurmaDisciplinaAutor" });
            DropTable("TaCerto.LogLogin");
            DropTable("TaCerto.TurmaAluno");
            DropTable("TaCerto.TipoQuestao");
            DropTable("TaCerto.Questao");
            DropTable("TaCerto.Midia");
            DropTable("TaCerto.Turma");
            DropTable("TaCerto.Disciplina");
            DropTable("TaCerto.DisciplinaTurma");
            DropTable("TaCerto.Endereco");
            DropTable("TaCerto.Instituicao");
            DropTable("TaCerto.Pessoa");
            DropTable("TaCerto.TurmaDisciplinaAutor");
            DropTable("TaCerto.Atividade");
        }
    }
}
