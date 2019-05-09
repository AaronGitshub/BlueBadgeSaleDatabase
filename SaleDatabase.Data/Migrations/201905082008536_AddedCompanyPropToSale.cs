namespace SaleDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyPropToSale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyLocation = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            AddColumn("dbo.Sale", "Company_CompanyID", c => c.Int());
            CreateIndex("dbo.Sale", "Company_CompanyID");
            AddForeignKey("dbo.Sale", "Company_CompanyID", "dbo.Company", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "Company_CompanyID", "dbo.Company");
            DropIndex("dbo.Sale", new[] { "Company_CompanyID" });
            DropColumn("dbo.Sale", "Company_CompanyID");
            DropTable("dbo.Company");
        }
    }
}
