namespace MvcOnlineTradeAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denemekargo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailid = c.Int(nullable: false, identity: true),
                        Statement = c.String(maxLength: 300, unicode: false),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Personnel = c.String(maxLength: 20, unicode: false),
                        Buyer = c.String(maxLength: 25, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailid);
            
            CreateTable(
                "dbo.CargoFollows",
                c => new
                    {
                        CargoFollowid = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Statement = c.String(maxLength: 100, unicode: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoFollowid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoFollows");
            DropTable("dbo.CargoDetails");
        }
    }
}
