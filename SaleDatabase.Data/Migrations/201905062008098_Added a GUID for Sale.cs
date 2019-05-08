namespace SaleDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedaGUIDforSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sale", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sale", "OwnerId");
        }
    }
}
