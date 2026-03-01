namespace AppGestionCahierText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiseAJourModele : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Role", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AddColumn("dbo.CahierTextes", "IdClasse", c => c.Int(nullable: false));
            AddColumn("dbo.CahierTextes", "IdAnnee", c => c.Int(nullable: false));
            AlterColumn("dbo.CahierTextes", "DescriptionCahierTexte", c => c.String(unicode: false));
            CreateIndex("dbo.CahierTextes", "IdClasse");
            CreateIndex("dbo.CahierTextes", "IdAnnee");
            AddForeignKey("dbo.CahierTextes", "IdAnnee", "dbo.AnneeAcademiques", "AnneeAcademiqueId", cascadeDelete: true);
            AddForeignKey("dbo.CahierTextes", "IdClasse", "dbo.Classes", "ClasseId", cascadeDelete: true);
            DropColumn("dbo.CahierTextes", "TitreCahierTexte");
            DropColumn("dbo.CahierTextes", "Annee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CahierTextes", "Annee", c => c.Int(nullable: false));
            AddColumn("dbo.CahierTextes", "TitreCahierTexte", c => c.String(nullable: false, maxLength: 150, storeType: "nvarchar"));
            DropForeignKey("dbo.CahierTextes", "IdClasse", "dbo.Classes");
            DropForeignKey("dbo.CahierTextes", "IdAnnee", "dbo.AnneeAcademiques");
            DropIndex("dbo.CahierTextes", new[] { "IdAnnee" });
            DropIndex("dbo.CahierTextes", new[] { "IdClasse" });
            AlterColumn("dbo.CahierTextes", "DescriptionCahierTexte", c => c.String(nullable: false, maxLength: 250, storeType: "nvarchar"));
            DropColumn("dbo.CahierTextes", "IdAnnee");
            DropColumn("dbo.CahierTextes", "IdClasse");
            DropColumn("dbo.Utilisateurs", "Role");
        }
    }
}
