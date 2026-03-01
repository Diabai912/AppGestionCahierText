namespace AppGestionCahierText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSyllabusConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Syllabus", "NiveauSyllabus", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Syllabus", "NiveauSyllabus", c => c.String(nullable: false, unicode: false));
        }
    }
}
