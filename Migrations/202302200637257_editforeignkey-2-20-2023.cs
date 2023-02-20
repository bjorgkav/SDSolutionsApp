namespace SDSolutionsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editforeignkey2202023 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecyclableItem", "RecyclableType_Id", "dbo.RecyclableType");
            DropIndex("dbo.RecyclableItem", new[] { "RecyclableType_Id" });
            RenameColumn(table: "dbo.RecyclableItem", name: "RecyclableType_Id", newName: "RecylableTypeId");
            AlterColumn("dbo.RecyclableItem", "Weight", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            AlterColumn("dbo.RecyclableItem", "ComputedRate", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            AlterColumn("dbo.RecyclableItem", "RecylableTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.RecyclableType", "Rate", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            AlterColumn("dbo.RecyclableType", "MinKg", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            AlterColumn("dbo.RecyclableType", "MaxKg", c => c.Decimal(nullable: false, precision: 20, scale: 2));
            CreateIndex("dbo.RecyclableItem", "RecylableTypeId");
            AddForeignKey("dbo.RecyclableItem", "RecylableTypeId", "dbo.RecyclableType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecyclableItem", "RecylableTypeId", "dbo.RecyclableType");
            DropIndex("dbo.RecyclableItem", new[] { "RecylableTypeId" });
            AlterColumn("dbo.RecyclableType", "MaxKg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RecyclableType", "MinKg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RecyclableType", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RecyclableItem", "RecylableTypeId", c => c.Int());
            AlterColumn("dbo.RecyclableItem", "ComputedRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RecyclableItem", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            RenameColumn(table: "dbo.RecyclableItem", name: "RecylableTypeId", newName: "RecyclableType_Id");
            CreateIndex("dbo.RecyclableItem", "RecyclableType_Id");
            AddForeignKey("dbo.RecyclableItem", "RecyclableType_Id", "dbo.RecyclableType", "Id");
        }
    }
}
