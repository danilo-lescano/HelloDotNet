namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matriz : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaCerto.Instituicao", "IsMatriz", c => c.Boolean(nullable: false));
            AddColumn("TaCerto.Instituicao", "IdMatriz", c => c.Int());
            AddColumn("TaCerto.Instituicao", "Matriz_IdInstituicao", c => c.Int());
            CreateIndex("TaCerto.Instituicao", "Matriz_IdInstituicao");
            AddForeignKey("TaCerto.Instituicao", "Matriz_IdInstituicao", "TaCerto.Instituicao", "IdInstituicao");
        }
        
        public override void Down()
        {
            DropForeignKey("TaCerto.Instituicao", "Matriz_IdInstituicao", "TaCerto.Instituicao");
            DropIndex("TaCerto.Instituicao", new[] { "Matriz_IdInstituicao" });
            DropColumn("TaCerto.Instituicao", "Matriz_IdInstituicao");
            DropColumn("TaCerto.Instituicao", "IdMatriz");
            DropColumn("TaCerto.Instituicao", "IsMatriz");
        }
    }
}
