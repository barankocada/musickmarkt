namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactadd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contects", "ContentID", "dbo.Contents");
            DropIndex("dbo.Contects", new[] { "ContentID" });
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserMail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Contents", t => t.ContentID, cascadeDelete: true)
                .Index(t => t.ContentID);
            
            DropTable("dbo.Contects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contects",
                c => new
                    {
                        ContectID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserMail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContectID);
            
            DropForeignKey("dbo.Contacts", "ContentID", "dbo.Contents");
            DropIndex("dbo.Contacts", new[] { "ContentID" });
            DropTable("dbo.Contacts");
            CreateIndex("dbo.Contects", "ContentID");
            AddForeignKey("dbo.Contects", "ContentID", "dbo.Contents", "ContentID", cascadeDelete: true);
        }
    }
}
