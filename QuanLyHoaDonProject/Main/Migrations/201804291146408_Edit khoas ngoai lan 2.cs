namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editkhoasngoailan2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans");
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs");
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToan_ID" });
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHang_ID" });
            RenameColumn(table: "dbo.HoaDonBans", name: "HinhThucThanhToan_ID", newName: "HinhThucThanhToanId");
            RenameColumn(table: "dbo.NguoiMuas", name: "DonViMuaHang_ID", newName: "DonViMuaHangId");
            AlterColumn("dbo.HoaDonBans", "HinhThucThanhToanId", c => c.Int(nullable: false));
            AlterColumn("dbo.NguoiMuas", "DonViMuaHangId", c => c.Int(nullable: false));
            CreateIndex("dbo.HoaDonBans", "HinhThucThanhToanId");
            CreateIndex("dbo.NguoiMuas", "DonViMuaHangId");
            AddForeignKey("dbo.HoaDonBans", "HinhThucThanhToanId", "dbo.HinhThucThanhToans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.NguoiMuas", "DonViMuaHangId", "dbo.DonViMuaHangs", "ID", cascadeDelete: true);
            DropColumn("dbo.HoaDonBans", "HTThanhToanId");
            DropColumn("dbo.NguoiMuas", "DonViMuaHanhId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiMuas", "DonViMuaHanhId", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "HTThanhToanId", c => c.Int(nullable: false));
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHangId", "dbo.DonViMuaHangs");
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToanId", "dbo.HinhThucThanhToans");
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHangId" });
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToanId" });
            AlterColumn("dbo.NguoiMuas", "DonViMuaHangId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "HinhThucThanhToanId", c => c.Int());
            RenameColumn(table: "dbo.NguoiMuas", name: "DonViMuaHangId", newName: "DonViMuaHang_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "HinhThucThanhToanId", newName: "HinhThucThanhToan_ID");
            CreateIndex("dbo.NguoiMuas", "DonViMuaHang_ID");
            CreateIndex("dbo.HoaDonBans", "HinhThucThanhToan_ID");
            AddForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs", "ID");
            AddForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans", "ID");
        }
    }
}
