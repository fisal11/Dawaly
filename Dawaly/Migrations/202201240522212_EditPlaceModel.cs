namespace Dawaly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPlaceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Places", "UserID");
            AddForeignKey("dbo.Places", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Places", new[] { "UserID" });
            DropColumn("dbo.Places", "UserID");
        }
    }
}
