namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisciplinaIdMatrizconstraint : DbMigration
    {
        public override void Up()
        {
            CreateIndex("TaCerto.Disciplina", "IdMatriz");
            AddForeignKey("TaCerto.Disciplina", "IdMatriz", "TaCerto.Instituicao", "IdInstituicao");
        }
        
        public override void Down()
        {
            DropForeignKey("TaCerto.Disciplina", "IdMatriz", "TaCerto.Instituicao");
            DropIndex("TaCerto.Disciplina", new[] { "IdMatriz" });
        }
    }
}
