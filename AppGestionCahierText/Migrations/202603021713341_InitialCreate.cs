namespace AppGestionCahierText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnneeAcademiques",
                c => new
                    {
                        AnneeAcademiqueId = c.Int(nullable: false, identity: true),
                        LibelleAnneeAcademique = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        ValueAnneeAcademique = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnneeAcademiqueId);
            
            CreateTable(
                "dbo.CahierTextes",
                c => new
                    {
                        IdCahierTexte = c.Int(nullable: false, identity: true),
                        IdClasse = c.Int(nullable: false),
                        DescriptionCahierTexte = c.String(unicode: false),
                        DateCahierTexte = c.DateTime(nullable: false, precision: 0),
                        IdAnnee = c.Int(nullable: false),
                        IdResponsable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCahierTexte)
                .ForeignKey("dbo.AnneeAcademiques", t => t.IdAnnee, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.IdClasse, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.IdResponsable, cascadeDelete: true)
                .Index(t => t.IdClasse)
                .Index(t => t.IdAnnee)
                .Index(t => t.IdResponsable);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClasseId = c.Int(nullable: false, identity: true),
                        LibelleClasse = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        AnneeAcademiqueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClasseId)
                .ForeignKey("dbo.AnneeAcademiques", t => t.AnneeAcademiqueId, cascadeDelete: true)
                .Index(t => t.AnneeAcademiqueId);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        IdUtilisateur = c.Int(nullable: false, identity: true),
                        NomUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        PrenomUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        AdresseUtilisateur = c.String(maxLength: 300, storeType: "nvarchar"),
                        EmailUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        TelephoneUtilisateur = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        Identifiant = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        PasswordHash = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        Salt = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Role = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        SpecialiteProfesseur = c.String(maxLength: 85, storeType: "nvarchar"),
                        MatriculeResponsable = c.String(maxLength: 20, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdUtilisateur);
            
            CreateTable(
                "dbo.DetailsSyllabus",
                c => new
                    {
                        IdDetailsSyllabus = c.Int(nullable: false, identity: true),
                        SeanceSyllabus = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        ContenuSyllabus = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        IdSyllabus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetailsSyllabus)
                .ForeignKey("dbo.Syllabus", t => t.IdSyllabus, cascadeDelete: true)
                .Index(t => t.IdSyllabus);
            
            CreateTable(
                "dbo.Syllabus",
                c => new
                    {
                        IdSyllabus = c.Int(nullable: false, identity: true),
                        LibelleSyllabus = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        DescriptionSyllabus = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        VolumeHoraireSyllabus = c.Int(nullable: false),
                        NiveauSyllabus = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdSyllabus);
            
            CreateTable(
                "dbo.matieres",
                c => new
                    {
                        IdMatiere = c.Int(nullable: false, identity: true),
                        LibelleMatiere = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        VolumeHoraireMatiere = c.Int(nullable: false),
                        Niveau = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        IdProfesseur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMatiere)
                .ForeignKey("dbo.Utilisateurs", t => t.IdProfesseur, cascadeDelete: true)
                .Index(t => t.IdProfesseur);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.matieres", "IdProfesseur", "dbo.Utilisateurs");
            DropForeignKey("dbo.DetailsSyllabus", "IdSyllabus", "dbo.Syllabus");
            DropForeignKey("dbo.CahierTextes", "IdResponsable", "dbo.Utilisateurs");
            DropForeignKey("dbo.CahierTextes", "IdClasse", "dbo.Classes");
            DropForeignKey("dbo.Classes", "AnneeAcademiqueId", "dbo.AnneeAcademiques");
            DropForeignKey("dbo.CahierTextes", "IdAnnee", "dbo.AnneeAcademiques");
            DropIndex("dbo.matieres", new[] { "IdProfesseur" });
            DropIndex("dbo.DetailsSyllabus", new[] { "IdSyllabus" });
            DropIndex("dbo.Classes", new[] { "AnneeAcademiqueId" });
            DropIndex("dbo.CahierTextes", new[] { "IdResponsable" });
            DropIndex("dbo.CahierTextes", new[] { "IdAnnee" });
            DropIndex("dbo.CahierTextes", new[] { "IdClasse" });
            DropTable("dbo.matieres");
            DropTable("dbo.Syllabus");
            DropTable("dbo.DetailsSyllabus");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Classes");
            DropTable("dbo.CahierTextes");
            DropTable("dbo.AnneeAcademiques");
        }
    }
}
