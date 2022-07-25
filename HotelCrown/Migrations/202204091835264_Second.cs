namespace HotelCrown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Customers", new[] { "ReservationId" });
            AlterColumn("dbo.Customers", "ReservationId", c => c.Int());
            CreateIndex("dbo.Customers", "ReservationId");
            AddForeignKey("dbo.Customers", "ReservationId", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ReservationId", "dbo.Reservations");
            DropIndex("dbo.Customers", new[] { "ReservationId" });
            AlterColumn("dbo.Customers", "ReservationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "ReservationId");
            AddForeignKey("dbo.Customers", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
