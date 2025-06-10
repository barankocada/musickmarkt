namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUsername = c.String(),
                        AdminPassword = c.String(),
                        adminRole = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
