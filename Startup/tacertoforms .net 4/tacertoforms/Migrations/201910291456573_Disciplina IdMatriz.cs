namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisciplinaIdMatriz : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaCerto.Disciplina", "IdMatriz", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TaCerto.Disciplina", "IdMatriz");
        }
    }
}
