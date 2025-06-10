namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_artist_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "ArtistAbout", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "ArtistAbout");
        }
    }
}
