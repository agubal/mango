namespace Mango.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationEmails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderName = c.String(),
                        SenderContactDetails = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailItems");
        }
    }
}
