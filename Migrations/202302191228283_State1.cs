namespace SDSolutionsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class State1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecyclableItem", "RecylableTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecyclableItem", "RecylableTypeId", c => c.Int(nullable: false));
        }
    }
}
