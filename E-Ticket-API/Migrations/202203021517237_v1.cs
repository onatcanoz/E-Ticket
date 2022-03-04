namespace E_Ticket_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vagons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        NumberOfFullSeats = c.Int(nullable: false),
                        TrainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.TrainId)
                .Index(t => t.TrainId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vagons", "TrainId", "dbo.Trains");
            DropIndex("dbo.Vagons", new[] { "TrainId" });
            DropTable("dbo.Vagons");
            DropTable("dbo.Trains");
        }
    }
}
