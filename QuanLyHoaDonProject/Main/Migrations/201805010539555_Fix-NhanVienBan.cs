namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNhanVienBan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVienBans", "SDT", c => c.String());
            AlterColumn("dbo.NhanVienBans", "HinhAnh", c => c.String(maxLength: 255));
            AlterColumn("dbo.NhanVienBans", "CMND", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVienBans", "CMND", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVienBans", "HinhAnh", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVienBans", "SDT", c => c.Int(nullable: false));
        }
    }
}
