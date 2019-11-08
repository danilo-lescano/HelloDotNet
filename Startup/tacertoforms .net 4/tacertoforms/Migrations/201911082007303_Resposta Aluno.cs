namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespostaAluno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TaCerto.AtividadeRespostaAluno",
                c => new
                    {
                        IdAtividadeRespostaAluno = c.Int(nullable: false, identity: true),
                        IdAtividade = c.Int(nullable: false),
                        IdPessoa = c.Int(nullable: false),
                        DataEnvio = c.DateTime(nullable: false),
                        Nota = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdAtividadeRespostaAluno)
                .ForeignKey("TaCerto.Atividade", t => t.IdAtividade)
                .ForeignKey("TaCerto.Pessoa", t => t.IdPessoa)
                .Index(t => t.IdAtividade)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "TaCerto.QuestaoRespostaAluno",
                c => new
                    {
                        IdQuestaoRespostaAluno = c.Int(nullable: false, identity: true),
                        IdAtividadeRespostaAluno = c.Int(nullable: false),
                        IdQuestao = c.Int(nullable: false),
                        NumAcerto = c.Int(nullable: false),
                        NumErro = c.Int(nullable: false),
                        JsonReposta = c.String(),
                        Nota = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdQuestaoRespostaAluno)
                .ForeignKey("TaCerto.AtividadeRespostaAluno", t => t.IdAtividadeRespostaAluno)
                .ForeignKey("TaCerto.Questao", t => t.IdQuestao)
                .Index(t => t.IdAtividadeRespostaAluno)
                .Index(t => t.IdQuestao);
        }
        
        public override void Down()
        {
            DropForeignKey("TaCerto.QuestaoRespostaAluno", "IdQuestao", "TaCerto.Questao");
            DropForeignKey("TaCerto.QuestaoRespostaAluno", "IdAtividadeRespostaAluno", "TaCerto.AtividadeRespostaAluno");
            DropForeignKey("TaCerto.AtividadeRespostaAluno", "IdPessoa", "TaCerto.Pessoa");
            DropForeignKey("TaCerto.AtividadeRespostaAluno", "IdAtividade", "TaCerto.Atividade");
            DropIndex("TaCerto.QuestaoRespostaAluno", new[] { "IdQuestao" });
            DropIndex("TaCerto.QuestaoRespostaAluno", new[] { "IdAtividadeRespostaAluno" });
            DropIndex("TaCerto.AtividadeRespostaAluno", new[] { "IdPessoa" });
            DropIndex("TaCerto.AtividadeRespostaAluno", new[] { "IdAtividade" });
            DropTable("TaCerto.QuestaoRespostaAluno");
            DropTable("TaCerto.AtividadeRespostaAluno");
        }
    }
}
