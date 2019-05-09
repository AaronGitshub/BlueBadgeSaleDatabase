namespace SaleDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyfinished : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "CompanyLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "CompanyLocation", c => c.String());
            AlterColumn("dbo.Company", "CompanyName", c => c.String());
        }
    }
}
