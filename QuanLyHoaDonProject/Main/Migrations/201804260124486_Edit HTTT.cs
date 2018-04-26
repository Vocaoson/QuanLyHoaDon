namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditHTTT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonViBanHangs", "MaSoThueBan", c => c.Int(nullable: false));
            AlterColumn("dbo.HinhThucThanhToans", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.DonViBanHangs", "MaSoThueMua");
            DropColumn("dbo.HinhThucThanhToans", "IDHoaDonBan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HinhThucThanhToans", "IDHoaDonBan", c => c.Int(nullable: false));
            AddColumn("dbo.DonViBanHangs", "MaSoThueMua", c => c.Int(nullable: false));
            AlterColumn("dbo.HinhThucThanhToans", "Name", c => c.String(maxLength: 20));
            DropColumn("dbo.DonViBanHangs", "MaSoThueBan");
        }
    }
}
