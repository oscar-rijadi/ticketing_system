namespace TicketingSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeatPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        TicketTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketTypes", t => t.TicketTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TicketTypeId);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatPositionId = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeatPositions", t => t.SeatPositionId, cascadeDelete: true)
                .Index(t => t.SeatPositionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropForeignKey("dbo.TicketTypes", "SeatPositionId", "dbo.SeatPositions");
            DropIndex("dbo.TicketTypes", new[] { "SeatPositionId" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.TicketTypes");
            DropTable("dbo.Tickets");
            DropTable("dbo.SeatPositions");
        }
    }
}
