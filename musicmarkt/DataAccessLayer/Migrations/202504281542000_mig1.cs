namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Contents", "ArtistID", C => C.Int());
            //CreateIndex("dbo.Contents", "ArtistID");
            //AddForeignKey("dbo.contents", "ArtistID", "DBO.Artists", "ArtistID");
        }
        
        public override void Down()
        {
        }
    }
}
