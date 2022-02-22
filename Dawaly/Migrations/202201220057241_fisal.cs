namespace Dawaly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fisal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Price");
        }
    }
}
