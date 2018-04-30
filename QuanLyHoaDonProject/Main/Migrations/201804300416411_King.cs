namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class King : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropForeignKey("dbo.CTHoaDons", "HangHoa_ID", "dbo.HangHoas");
            DropForeignKey("dbo.CTHoaDons", "HoaDonBan_ID", "dbo.HoaDonBans");
            DropForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans");
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans");
            DropForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas");
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs");
            DropIndex("dbo.CTHoaDons", new[] { "HangHoa_ID" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBan_ID" });
            DropIndex("dbo.HangHoas", new[] { "DonViBanHang_ID" });
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHang_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToan_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMua_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBan_ID" });
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHang_ID" });
            RenameColumn(table: "dbo.CTHoaDons", name: "HangHoa_ID", newName: "HangHoaId");
            RenameColumn(table: "dbo.CTHoaDons", name: "HoaDonBan_ID", newName: "HoaDonBanId");
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHang_ID", newName: "DonViBanHangId");
            RenameColumn(table: "dbo.HoaDonBans", name: "NhanVienBan_ID", newName: "NhanVienBanId");
            RenameColumn(table: "dbo.HoaDonBans", name: "HinhThucThanhToan_ID", newName: "HinhThucThanhToanId");
            RenameColumn(table: "dbo.HoaDonBans", name: "NguoiMua_ID", newName: "NguoiMuaId");
            RenameColumn(table: "dbo.NguoiMuas", name: "DonViMuaHang_ID", newName: "DonViMuaHangId");
            DropPrimaryKey("dbo.CTHoaDons");
            AlterColumn("dbo.CTHoaDons", "HangHoaId", c => c.Int(nullable: false));
            AlterColumn("dbo.CTHoaDons", "HoaDonBanId", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVienBans", "DonViBanHangId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDonBans", "HinhThucThanhToanId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDonBans", "NguoiMuaId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDonBans", "NhanVienBanId", c => c.Int(nullable: false));
            AlterColumn("dbo.NguoiMuas", "DonViMuaHangId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CTHoaDons", new[] { "HoaDonBanId", "HangHoaId" });
            CreateIndex("dbo.CTHoaDons", "HoaDonBanId");
            CreateIndex("dbo.CTHoaDons", "HangHoaId");
            CreateIndex("dbo.HoaDonBans", "HinhThucThanhToanId");
            CreateIndex("dbo.HoaDonBans", "NguoiMuaId");
            CreateIndex("dbo.HoaDonBans", "NhanVienBanId");
            CreateIndex("dbo.NguoiMuas", "DonViMuaHangId");
            CreateIndex("dbo.NhanVienBans", "DonViBanHangId");
            AddForeignKey("dbo.CTHoaDons", "HangHoaId", "dbo.HangHoas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CTHoaDons", "HoaDonBanId", "dbo.HoaDonBans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HoaDonBans", "NhanVienBanId", "dbo.NhanVienBans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HoaDonBans", "HinhThucThanhToanId", "dbo.HinhThucThanhToans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HoaDonBans", "NguoiMuaId", "dbo.NguoiMuas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.NguoiMuas", "DonViMuaHangId", "dbo.DonViMuaHangs", "ID", cascadeDelete: true);
            DropColumn("dbo.CTHoaDons", "IDHoaDonBan");
            DropColumn("dbo.CTHoaDons", "IDHangHoa");
            DropColumn("dbo.HangHoas", "IDDonViBanHang");
            DropColumn("dbo.HangHoas", "DonViBanHang_ID");
            DropColumn("dbo.NhanVienBans", "IDDonViBanHang");
            DropColumn("dbo.HoaDonBans", "IDHTThanhToan");
            DropColumn("dbo.HoaDonBans", "IDNguoiMua");
            DropColumn("dbo.HoaDonBans", "IDNhanVienBan");
            DropColumn("dbo.NguoiMuas", "IDDonViMuaHanh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiMuas", "IDDonViMuaHanh", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNhanVienBan", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNguoiMua", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDHTThanhToan", c => c.Int(nullable: false));
            AddColumn("dbo.NhanVienBans", "IDDonViBanHang", c => c.Int(nullable: false));
            AddColumn("dbo.HangHoas", "DonViBanHang_ID", c => c.Int());
            AddColumn("dbo.HangHoas", "IDDonViBanHang", c => c.Int(nullable: false));
            AddColumn("dbo.CTHoaDons", "IDHangHoa", c => c.Int(nullable: false));
            AddColumn("dbo.CTHoaDons", "IDHoaDonBan", c => c.Int(nullable: false));
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHangId", "dbo.DonViMuaHangs");
            DropForeignKey("dbo.HoaDonBans", "NguoiMuaId", "dbo.NguoiMuas");
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToanId", "dbo.HinhThucThanhToans");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBanId", "dbo.NhanVienBans");
            DropForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs");
            DropForeignKey("dbo.CTHoaDons", "HoaDonBanId", "dbo.HoaDonBans");
            DropForeignKey("dbo.CTHoaDons", "HangHoaId", "dbo.HangHoas");
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHangId" });
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHangId" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBanId" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMuaId" });
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToanId" });
            DropIndex("dbo.CTHoaDons", new[] { "HangHoaId" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBanId" });
            DropPrimaryKey("dbo.CTHoaDons");
            AlterColumn("dbo.NguoiMuas", "DonViMuaHangId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "NhanVienBanId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "NguoiMuaId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "HinhThucThanhToanId", c => c.Int());
            AlterColumn("dbo.NhanVienBans", "DonViBanHangId", c => c.Int());
            AlterColumn("dbo.CTHoaDons", "HoaDonBanId", c => c.Int());
            AlterColumn("dbo.CTHoaDons", "HangHoaId", c => c.Int());
            AddPrimaryKey("dbo.CTHoaDons", new[] { "IDHoaDonBan", "IDHangHoa" });
            RenameColumn(table: "dbo.NguoiMuas", name: "DonViMuaHangId", newName: "DonViMuaHang_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "NguoiMuaId", newName: "NguoiMua_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "HinhThucThanhToanId", newName: "HinhThucThanhToan_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "NhanVienBanId", newName: "NhanVienBan_ID");
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHangId", newName: "DonViBanHang_ID");
            RenameColumn(table: "dbo.CTHoaDons", name: "HoaDonBanId", newName: "HoaDonBan_ID");
            RenameColumn(table: "dbo.CTHoaDons", name: "HangHoaId", newName: "HangHoa_ID");
            CreateIndex("dbo.NguoiMuas", "DonViMuaHang_ID");
            CreateIndex("dbo.HoaDonBans", "NhanVienBan_ID");
            CreateIndex("dbo.HoaDonBans", "NguoiMua_ID");
            CreateIndex("dbo.HoaDonBans", "HinhThucThanhToan_ID");
            CreateIndex("dbo.NhanVienBans", "DonViBanHang_ID");
            CreateIndex("dbo.HangHoas", "DonViBanHang_ID");
            CreateIndex("dbo.CTHoaDons", "HoaDonBan_ID");
            CreateIndex("dbo.CTHoaDons", "HangHoa_ID");
            AddForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs", "ID");
            AddForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas", "ID");
            AddForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans", "ID");
            AddForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans", "ID");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
            AddForeignKey("dbo.CTHoaDons", "HoaDonBan_ID", "dbo.HoaDonBans", "ID");
            AddForeignKey("dbo.CTHoaDons", "HangHoa_ID", "dbo.HangHoas", "ID");
            AddForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
        }
    }
}
