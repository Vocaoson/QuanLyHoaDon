namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtongTienHoaDon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDonBans", "TongTienSo", c => c.String(maxLength: 100));
            AddColumn("dbo.HoaDonBans", "TongTienChu", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoaDonBans", "TongTienChu");
            DropColumn("dbo.HoaDonBans", "TongTienSo");
        }
    }
}
