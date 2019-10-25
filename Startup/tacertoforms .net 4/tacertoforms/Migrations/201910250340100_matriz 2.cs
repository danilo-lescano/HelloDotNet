namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matriz2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("TaCerto.Instituicao", "IdMatriz");
            RenameColumn(table: "TaCerto.Instituicao", name: "Matriz_IdInstituicao", newName: "IdMatriz");
            RenameIndex(table: "TaCerto.Instituicao", name: "IX_Matriz_IdInstituicao", newName: "IX_IdMatriz");
        }
        
        public override void Down()
        {
            RenameIndex(table: "TaCerto.Instituicao", name: "IX_IdMatriz", newName: "IX_Matriz_IdInstituicao");
            RenameColumn(table: "TaCerto.Instituicao", name: "IdMatriz", newName: "Matriz_IdInstituicao");
            AddColumn("TaCerto.Instituicao", "IdMatriz", c => c.Int());
        }
    }
}
