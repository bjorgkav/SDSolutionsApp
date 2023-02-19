namespace SDSolutionsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevarcharlength2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecyclableItem", "ItemDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.RecyclableType", "Type", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecyclableType", "Type", c => c.String());
            AlterColumn("dbo.RecyclableItem", "ItemDescription", c => c.String());
        }
    }
}
