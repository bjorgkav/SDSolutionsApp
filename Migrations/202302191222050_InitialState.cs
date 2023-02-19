namespace SDSolutionsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecyclableItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecylableTypeId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComputedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescription = c.String(),
                        RecyclableType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecyclableType", t => t.RecyclableType_Id)
                .Index(t => t.RecyclableType_Id);
            
            CreateTable(
                "dbo.RecyclableType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecyclableItem", "RecyclableType_Id", "dbo.RecyclableType");
            DropIndex("dbo.RecyclableItem", new[] { "RecyclableType_Id" });
            DropTable("dbo.RecyclableType");
            DropTable("dbo.RecyclableItem");
        }
    }
}
