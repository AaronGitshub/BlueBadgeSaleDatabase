namespace SaleDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sale", "SaleType", c => c.String());
            AlterColumn("dbo.Sale", "Buyer1", c => c.String());
            AlterColumn("dbo.Sale", "Seller1", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sale", "Seller1", c => c.String(nullable: false));
            AlterColumn("dbo.Sale", "Buyer1", c => c.String(nullable: false));
            AlterColumn("dbo.Sale", "SaleType", c => c.String(nullable: false));
        }
    }
}
