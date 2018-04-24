namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHoaDons",
                c => new
                    {
                        IDHoaDonBan = c.Int(nullable: false),
                        IDHangHoa = c.Int(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                        SoLuongBan = c.Int(nullable: false),
                        HangHoa_ID = c.Int(),
                        HoaDonBan_ID = c.Int(),
                    })
                .PrimaryKey(t => new { t.IDHoaDonBan, t.IDHangHoa })
                .ForeignKey("dbo.HangHoas", t => t.HangHoa_ID)
                .ForeignKey("dbo.HoaDonBans", t => t.HoaDonBan_ID)
                .Index(t => t.HangHoa_ID)
                .Index(t => t.HoaDonBan_ID);
            
            AddColumn("dbo.DonViBanHangs", "Logo", c => c.Int(nullable: false));
            AddColumn("dbo.DonViBanHangs", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.DonViBanHangs", "MaSoThueMua", c => c.Int(nullable: false));
            AddColumn("dbo.DonViBanHangs", "DiaChi", c => c.String(maxLength: 50));
            AddColumn("dbo.DonViBanHangs", "STKBan", c => c.Int(nullable: false));
            AddColumn("dbo.DonViBanHangs", "SDTBan", c => c.Int(nullable: false));
            AddColumn("dbo.DonViMuaHangs", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.DonViMuaHangs", "DiaChiMua", c => c.String(maxLength: 50));
            AddColumn("dbo.DonViMuaHangs", "MaSoThueMua", c => c.Int(nullable: false));
            AddColumn("dbo.DonViMuaHangs", "STKMua", c => c.Int(nullable: false));
            AddColumn("dbo.DonViMuaHangs", "SDTMua", c => c.Int(nullable: false));
            AddColumn("dbo.HangHoas", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.HangHoas", "DVT", c => c.String(maxLength: 50));
            AddColumn("dbo.HangHoas", "SoLuong", c => c.Int(nullable: false));
            AddColumn("dbo.HangHoas", "DonGiaNhap", c => c.Double(nullable: false));
            AddColumn("dbo.HangHoas", "DonGiaBan", c => c.Double(nullable: false));
            AddColumn("dbo.HangHoas", "GhiChu", c => c.String(maxLength: 250));
            AddColumn("dbo.HangHoas", "IDDonViBanHang", c => c.Int(nullable: false));
            AddColumn("dbo.HangHoas", "DonViBanHang_ID", c => c.Int());
            AddColumn("dbo.HinhThucThanhToans", "Name", c => c.String(maxLength: 20));
            AddColumn("dbo.HinhThucThanhToans", "IDHoaDonBan", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "ThueSuat", c => c.Double(nullable: false));
            AddColumn("dbo.HoaDonBans", "KyHieu", c => c.String(maxLength: 50));
            AddColumn("dbo.HoaDonBans", "NgayHD", c => c.DateTime(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDHTThanhToan", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNguoiMua", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNhanVienBan", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "HinhThucThanhToan_ID", c => c.Int());
            AddColumn("dbo.HoaDonBans", "NguoiMua_ID", c => c.Int());
            AddColumn("dbo.HoaDonBans", "NhanVienBan_ID", c => c.Int());
            AddColumn("dbo.NguoiMuas", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.NguoiMuas", "IDDonViMuaHanh", c => c.Int(nullable: false));
            AddColumn("dbo.NguoiMuas", "DonViMuaHang_ID", c => c.Int());
            AddColumn("dbo.NhanVienBans", "Name", c => c.String(maxLength: 100));
            AddColumn("dbo.NhanVienBans", "GioiTinh", c => c.String(maxLength: 20));
            AddColumn("dbo.NhanVienBans", "SDT", c => c.Int(nullable: false));
            AddColumn("dbo.NhanVienBans", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.NhanVienBans", "TTLamViec", c => c.String(maxLength: 100));
            AddColumn("dbo.NhanVienBans", "HinhAnh", c => c.Int(nullable: false));
            AddColumn("dbo.NhanVienBans", "CMND", c => c.Int(nullable: false));
            AddColumn("dbo.NhanVienBans", "NgayCap", c => c.DateTime(nullable: false));
            AddColumn("dbo.NhanVienBans", "NoiCap", c => c.String(maxLength: 100));
            AddColumn("dbo.NhanVienBans", "IDDonViBanHang", c => c.Int(nullable: false));
            AddColumn("dbo.NhanVienBans", "DonViBanHang_ID", c => c.Int());
            CreateIndex("dbo.HangHoas", "DonViBanHang_ID");
            CreateIndex("dbo.NhanVienBans", "DonViBanHang_ID");
            CreateIndex("dbo.HoaDonBans", "HinhThucThanhToan_ID");
            CreateIndex("dbo.HoaDonBans", "NguoiMua_ID");
            CreateIndex("dbo.HoaDonBans", "NhanVienBan_ID");
            CreateIndex("dbo.NguoiMuas", "DonViMuaHang_ID");
            AddForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
            AddForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans", "ID");
            AddForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs", "ID");
            AddForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas", "ID");
            AddForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTHoaDons", "HoaDonBan_ID", "dbo.HoaDonBans");
            DropForeignKey("dbo.CTHoaDons", "HangHoa_ID", "dbo.HangHoas");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans");
            DropForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas");
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHang_ID", "dbo.DonViMuaHangs");
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToan_ID", "dbo.HinhThucThanhToans");
            DropForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHang_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBan_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMua_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToan_ID" });
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHang_ID" });
            DropIndex("dbo.HangHoas", new[] { "DonViBanHang_ID" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBan_ID" });
            DropIndex("dbo.CTHoaDons", new[] { "HangHoa_ID" });
            DropColumn("dbo.NhanVienBans", "DonViBanHang_ID");
            DropColumn("dbo.NhanVienBans", "IDDonViBanHang");
            DropColumn("dbo.NhanVienBans", "NoiCap");
            DropColumn("dbo.NhanVienBans", "NgayCap");
            DropColumn("dbo.NhanVienBans", "CMND");
            DropColumn("dbo.NhanVienBans", "HinhAnh");
            DropColumn("dbo.NhanVienBans", "TTLamViec");
            DropColumn("dbo.NhanVienBans", "DOB");
            DropColumn("dbo.NhanVienBans", "SDT");
            DropColumn("dbo.NhanVienBans", "GioiTinh");
            DropColumn("dbo.NhanVienBans", "Name");
            DropColumn("dbo.NguoiMuas", "DonViMuaHang_ID");
            DropColumn("dbo.NguoiMuas", "IDDonViMuaHanh");
            DropColumn("dbo.NguoiMuas", "Name");
            DropColumn("dbo.HoaDonBans", "NhanVienBan_ID");
            DropColumn("dbo.HoaDonBans", "NguoiMua_ID");
            DropColumn("dbo.HoaDonBans", "HinhThucThanhToan_ID");
            DropColumn("dbo.HoaDonBans", "IDNhanVienBan");
            DropColumn("dbo.HoaDonBans", "IDNguoiMua");
            DropColumn("dbo.HoaDonBans", "IDHTThanhToan");
            DropColumn("dbo.HoaDonBans", "NgayHD");
            DropColumn("dbo.HoaDonBans", "KyHieu");
            DropColumn("dbo.HoaDonBans", "ThueSuat");
            DropColumn("dbo.HinhThucThanhToans", "IDHoaDonBan");
            DropColumn("dbo.HinhThucThanhToans", "Name");
            DropColumn("dbo.HangHoas", "DonViBanHang_ID");
            DropColumn("dbo.HangHoas", "IDDonViBanHang");
            DropColumn("dbo.HangHoas", "GhiChu");
            DropColumn("dbo.HangHoas", "DonGiaBan");
            DropColumn("dbo.HangHoas", "DonGiaNhap");
            DropColumn("dbo.HangHoas", "SoLuong");
            DropColumn("dbo.HangHoas", "DVT");
            DropColumn("dbo.HangHoas", "Name");
            DropColumn("dbo.DonViMuaHangs", "SDTMua");
            DropColumn("dbo.DonViMuaHangs", "STKMua");
            DropColumn("dbo.DonViMuaHangs", "MaSoThueMua");
            DropColumn("dbo.DonViMuaHangs", "DiaChiMua");
            DropColumn("dbo.DonViMuaHangs", "Name");
            DropColumn("dbo.DonViBanHangs", "SDTBan");
            DropColumn("dbo.DonViBanHangs", "STKBan");
            DropColumn("dbo.DonViBanHangs", "DiaChi");
            DropColumn("dbo.DonViBanHangs", "MaSoThueMua");
            DropColumn("dbo.DonViBanHangs", "Name");
            DropColumn("dbo.DonViBanHangs", "Logo");
            DropTable("dbo.CTHoaDons");
        }
    }
}
