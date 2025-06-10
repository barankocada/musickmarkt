namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addsonstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SonStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "SonStatus");
        }
    }
}
