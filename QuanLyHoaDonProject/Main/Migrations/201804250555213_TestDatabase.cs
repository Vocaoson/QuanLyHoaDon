namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDatabase : DbMigration
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
            
            CreateTable(
                "dbo.HangHoas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DVT = c.String(maxLength: 50),
                        SoLuong = c.Int(nullable: false),
                        DonGiaNhap = c.Double(nullable: false),
                        DonGiaBan = c.Double(nullable: false),
                        GhiChu = c.String(maxLength: 250),
                        IDDonViBanHang = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                        DonViBanHang_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonViBanHangs", t => t.DonViBanHang_ID)
                .Index(t => t.DonViBanHang_ID);
            
            CreateTable(
                "dbo.DonViBanHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        MaSoThueMua = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 50),
                        STKBan = c.Int(nullable: false),
                        SDTBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NhanVienBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        GioiTinh = c.String(maxLength: 20),
                        SDT = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        TTLamViec = c.String(maxLength: 100),
                        HinhAnh = c.Int(nullable: false),
                        CMND = c.Int(nullable: false),
                        NgayCap = c.DateTime(nullable: false),
                        NoiCap = c.String(maxLength: 100),
                        DaXoa = c.Boolean(nullable: false),
                        IDDonViBanHang = c.Int(nullable: false),
                        DonViBanHang_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonViBanHangs", t => t.DonViBanHang_ID)
                .Index(t => t.DonViBanHang_ID);
            
            CreateTable(
                "dbo.HoaDonBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThueSuat = c.Double(nullable: false),
                        KyHieu = c.String(maxLength: 50),
                        NgayHD = c.DateTime(nullable: false),
                        IDHTThanhToan = c.Int(nullable: false),
                        IDNguoiMua = c.Int(nullable: false),
                        IDNhanVienBan = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                        HinhThucThanhToan_ID = c.Int(),
                        NguoiMua_ID = c.Int(),
                        NhanVienBan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HinhThucThanhToans", t => t.HinhThucThanhToan_ID)
                .ForeignKey("dbo.NguoiMuas", t => t.NguoiMua_ID)
                .ForeignKey("dbo.NhanVienBans", t => t.NhanVienBan_ID)
                .Index(t => t.HinhThucThanhToan_ID)
                .Index(t => t.NguoiMua_ID)
                .Index(t => t.NhanVienBan_ID);
            
            CreateTable(
                "dbo.HinhThucThanhToans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        IDHoaDonBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NguoiMuas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IDDonViMuaHanh = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                        DonViMuaHang_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonViMuaHangs", t => t.DonViMuaHang_ID)
                .Index(t => t.DonViMuaHang_ID);
            
            CreateTable(
                "dbo.DonViMuaHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DiaChiMua = c.String(maxLength: 50),
                        MaSoThueMua = c.Int(nullable: false),
                        STKMua = c.Int(nullable: false),
                        SDTMua = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropTable("dbo.DonViMuaHangs");
            DropTable("dbo.NguoiMuas");
            DropTable("dbo.HinhThucThanhToans");
            DropTable("dbo.HoaDonBans");
            DropTable("dbo.NhanVienBans");
            DropTable("dbo.DonViBanHangs");
            DropTable("dbo.HangHoas");
            DropTable("dbo.CTHoaDons");
        }
    }
}
