namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_artist_addstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "ArtistStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "ArtistStatus");
        }
    }
}
