namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class procedure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        ProcedureId = c.Int(nullable: false, identity: true),
                        ProcedureName = c.String(),
                        ProcedureDoctor = c.Int(nullable: false),
                        ProcedurePatient = c.Int(nullable: false),
                        ProcedureRoom = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProcedureId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Procedures");
        }
    }
}
