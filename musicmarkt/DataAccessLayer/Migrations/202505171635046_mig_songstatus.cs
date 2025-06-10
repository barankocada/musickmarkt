namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_songstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "SongStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Songs", "SonStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "SonStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Songs", "SongStatus");
        }
    }
}
