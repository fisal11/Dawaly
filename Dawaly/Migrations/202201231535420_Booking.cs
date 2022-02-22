namespace Dawaly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyToPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PlaceId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyToPlaces", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyToPlaces", "PlaceId", "dbo.Places");
            DropIndex("dbo.ApplyToPlaces", new[] { "UserId" });
            DropIndex("dbo.ApplyToPlaces", new[] { "PlaceId" });
            DropTable("dbo.ApplyToPlaces");
        }
    }
}
