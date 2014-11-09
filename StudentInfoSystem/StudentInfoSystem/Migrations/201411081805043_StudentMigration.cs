namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Roll = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropTable("dbo.Students");
        }
    }
}
