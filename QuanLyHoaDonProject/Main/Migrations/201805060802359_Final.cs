namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHoaDons",
                c => new
                    {
                        HoaDonBanId = c.Int(nullable: false),
                        HangHoaId = c.Int(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                        SoLuongBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HoaDonBanId, t.HangHoaId })
                .ForeignKey("dbo.HangHoas", t => t.HangHoaId, cascadeDelete: true)
                .ForeignKey("dbo.HoaDonBans", t => t.HoaDonBanId, cascadeDelete: true)
                .Index(t => t.HoaDonBanId)
                .Index(t => t.HangHoaId);
            
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
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HoaDonBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThueSuat = c.Double(nullable: false),
                        KyHieu = c.String(maxLength: 50),
                        NgayHD = c.DateTime(nullable: false),
                        HinhThucThanhToanId = c.Int(nullable: false),
                        NguoiMuaId = c.Int(nullable: false),
                        NhanVienBanId = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HinhThucThanhToans", t => t.HinhThucThanhToanId, cascadeDelete: true)
                .ForeignKey("dbo.NguoiMuas", t => t.NguoiMuaId, cascadeDelete: true)
                .ForeignKey("dbo.NhanVienBans", t => t.NhanVienBanId, cascadeDelete: true)
                .Index(t => t.HinhThucThanhToanId)
                .Index(t => t.NguoiMuaId)
                .Index(t => t.NhanVienBanId);
            
            CreateTable(
                "dbo.HinhThucThanhToans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NguoiMuas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DonViMuaHangId = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonViMuaHangs", t => t.DonViMuaHangId, cascadeDelete: true)
                .Index(t => t.DonViMuaHangId);
            
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
            
            CreateTable(
                "dbo.NhanVienBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        GioiTinh = c.String(maxLength: 20),
                        SDT = c.String(),
                        DOB = c.DateTime(nullable: false),
                        TTLamViec = c.String(maxLength: 100),
                        HinhAnh = c.String(maxLength: 255),
                        DiaChi = c.String(maxLength: 255),
                        CMND = c.String(maxLength: 100),
                        NgayCap = c.DateTime(),
                        NoiCap = c.String(maxLength: 100),
                        DaXoa = c.Boolean(nullable: false),
                        HonNhan = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DangNhaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(maxLength: 100),
                        PassWord = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DonViBanHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        MaSoThueBan = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 50),
                        STKBan = c.Int(nullable: false),
                        SDTBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTHoaDons", "HoaDonBanId", "dbo.HoaDonBans");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBanId", "dbo.NhanVienBans");
            DropForeignKey("dbo.HoaDonBans", "NguoiMuaId", "dbo.NguoiMuas");
            DropForeignKey("dbo.NguoiMuas", "DonViMuaHangId", "dbo.DonViMuaHangs");
            DropForeignKey("dbo.HoaDonBans", "HinhThucThanhToanId", "dbo.HinhThucThanhToans");
            DropForeignKey("dbo.CTHoaDons", "HangHoaId", "dbo.HangHoas");
            DropIndex("dbo.NguoiMuas", new[] { "DonViMuaHangId" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBanId" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMuaId" });
            DropIndex("dbo.HoaDonBans", new[] { "HinhThucThanhToanId" });
            DropIndex("dbo.CTHoaDons", new[] { "HangHoaId" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBanId" });
            DropTable("dbo.DonViBanHangs");
            DropTable("dbo.DangNhaps");
            DropTable("dbo.NhanVienBans");
            DropTable("dbo.DonViMuaHangs");
            DropTable("dbo.NguoiMuas");
            DropTable("dbo.HinhThucThanhToans");
            DropTable("dbo.HoaDonBans");
            DropTable("dbo.HangHoas");
            DropTable("dbo.CTHoaDons");
        }
    }
}
