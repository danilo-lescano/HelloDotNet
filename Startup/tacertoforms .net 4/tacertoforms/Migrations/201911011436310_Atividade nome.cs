namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atividadenome : DbMigration
    {
        public override void Up()
        {
            AddColumn("TaCerto.Atividade", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("TaCerto.Atividade", "Nome");
        }
    }
}
