namespace Dawaly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mohamed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Image", c => c.String(nullable: false));
        }
    }
}
