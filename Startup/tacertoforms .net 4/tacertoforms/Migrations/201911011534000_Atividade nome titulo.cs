namespace tacertoforms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Atividadenometitulo : DbMigration
    {
        public override void Up()
        {
            RenameColumn("TaCerto.Atividade", "Nome", "Titulo");
        }

        public override void Down()
        {
            RenameColumn("TaCerto.Atividade", "Titulo", "Nome");
        }
    }
}