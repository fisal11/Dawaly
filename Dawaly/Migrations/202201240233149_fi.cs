namespace Dawaly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplyToPlaces", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplyToPlaces", "Message", c => c.String());
        }
    }
}
