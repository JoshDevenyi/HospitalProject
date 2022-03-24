namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeysprocedures : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Procedures", "ProcedureDoctor");
            CreateIndex("dbo.Procedures", "ProcedurePatient");
            CreateIndex("dbo.Procedures", "ProcedureRoom");
            AddForeignKey("dbo.Procedures", "ProcedureDoctor", "dbo.Doctors", "DoctorId", cascadeDelete: true);
            AddForeignKey("dbo.Procedures", "ProcedurePatient", "dbo.Patients", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Procedures", "ProcedureRoom", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedures", "ProcedureRoom", "dbo.Rooms");
            DropForeignKey("dbo.Procedures", "ProcedurePatient", "dbo.Patients");
            DropForeignKey("dbo.Procedures", "ProcedureDoctor", "dbo.Doctors");
            DropIndex("dbo.Procedures", new[] { "ProcedureRoom" });
            DropIndex("dbo.Procedures", new[] { "ProcedurePatient" });
            DropIndex("dbo.Procedures", new[] { "ProcedureDoctor" });
        }
    }
}
