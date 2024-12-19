namespace AMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseDone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CheckInTime = c.Time(nullable: false, precision: 7),
                        CheckOutTime = c.Time(nullable: false, precision: 7),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SettingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "UserId", "dbo.Users");
            DropIndex("dbo.Attendances", new[] { "UserId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Users");
            DropTable("dbo.Attendances");
        }
    }
}
