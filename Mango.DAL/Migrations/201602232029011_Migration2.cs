namespace Mango.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "IsMain", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "IsMain", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Technologies", "IsMain", c => c.Boolean(nullable: false));
            AddColumn("dbo.Technologies", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Technologies", "Order");
            DropColumn("dbo.Technologies", "IsMain");
            DropColumn("dbo.Services", "Order");
            DropColumn("dbo.Services", "IsMain");
            DropColumn("dbo.Clients", "Order");
            DropColumn("dbo.Clients", "IsMain");
        }
    }
}
