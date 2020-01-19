namespace LMSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lms_systemv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowedBooks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sId = c.Int(),
                        bId = c.Int(),
                        StudentId = c.String(),
                        StudentName = c.String(),
                        Title = c.String(),
                        author = c.String(),
                        Publisher = c.String(),
                        subjectMatter = c.String(),
                        isReturned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        studendID = c.String(nullable: false),
                        Year = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Books", "imagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "imagePath", c => c.String(nullable: false));
            DropTable("dbo.Students");
            DropTable("dbo.BorrowedBooks");
        }
    }
}
