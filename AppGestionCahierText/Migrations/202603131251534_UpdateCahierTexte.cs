namespace AppGestionCahierText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCahierTexte : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CahierTextes", "TitreCahierTexte");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CahierTextes", "TitreCahierTexte", c => c.String(nullable: false, maxLength: 200, storeType: "nvarchar"));
        }
    }
}
