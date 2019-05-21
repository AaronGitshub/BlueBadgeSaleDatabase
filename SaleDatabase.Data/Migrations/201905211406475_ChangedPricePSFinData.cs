namespace SaleDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPricePSFinData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sale", "PricePerSF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "PricePerSF", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
