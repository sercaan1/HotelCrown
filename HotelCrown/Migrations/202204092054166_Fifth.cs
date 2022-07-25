namespace HotelCrown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "CheckInDate", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CheckOutDate", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CheckedInTime", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CheckedOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "CheckedOutTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckedInTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckInDate", c => c.DateTime(nullable: false));
        }
    }
}
