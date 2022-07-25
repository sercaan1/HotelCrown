namespace HotelCrown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        IdentityNumber = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Description = c.String(),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        CheckedInTime = c.DateTime(nullable: false),
                        CheckedOutTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        Capacity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.FeatureRooms",
                c => new
                    {
                        Feature_Id = c.Int(nullable: false),
                        Room_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Feature_Id, t.Room_Id })
                .ForeignKey("dbo.Features", t => t.Feature_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.Feature_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.ServiceCustomers",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Customer_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceDetails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ServiceCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ServiceCustomers", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.FeatureRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.FeatureRooms", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.Customers", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.ServiceCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.ServiceCustomers", new[] { "Service_Id" });
            DropIndex("dbo.FeatureRooms", new[] { "Room_Id" });
            DropIndex("dbo.FeatureRooms", new[] { "Feature_Id" });
            DropIndex("dbo.ServiceDetails", new[] { "CustomerId" });
            DropIndex("dbo.ServiceDetails", new[] { "ServiceId" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Customers", new[] { "ReservationId" });
            DropTable("dbo.ServiceCustomers");
            DropTable("dbo.FeatureRooms");
            DropTable("dbo.ServiceDetails");
            DropTable("dbo.Services");
            DropTable("dbo.Features");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
        }
    }
}
