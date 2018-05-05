namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NhanVienBanDonViBanHang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHang_ID" });
            DropColumn("dbo.NhanVienBans", "DonViBanHang_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanVienBans", "DonViBanHang_ID", c => c.Int());
            CreateIndex("dbo.NhanVienBans", "DonViBanHang_ID");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
        }
    }
}
