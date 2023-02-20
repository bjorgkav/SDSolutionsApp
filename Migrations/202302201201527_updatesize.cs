namespace SDSolutionsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesize : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RecyclableType", new[] { "Type" });
            AlterColumn("dbo.RecyclableType", "Type", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.RecyclableType", "Type", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.RecyclableType", new[] { "Type" });
            AlterColumn("dbo.RecyclableType", "Type", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.RecyclableType", "Type", unique: true);
        }
    }
}
