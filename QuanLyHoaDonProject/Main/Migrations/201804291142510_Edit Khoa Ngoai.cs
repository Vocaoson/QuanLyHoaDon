namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditKhoaNgoai : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTHoaDons", "HangHoa_ID", "dbo.HangHoas");
            DropForeignKey("dbo.CTHoaDons", "HoaDonBan_ID", "dbo.HoaDonBans");
            DropForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans");
            DropForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropIndex("dbo.CTHoaDons", new[] { "HangHoa_ID" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBan_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMua_ID" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBan_ID" });
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHang_ID" });
            RenameColumn(table: "dbo.CTHoaDons", name: "HangHoa_ID", newName: "HangHoaId");
            RenameColumn(table: "dbo.CTHoaDons", name: "HoaDonBan_ID", newName: "HoaDonBanId");
            RenameColumn(table: "dbo.HoaDonBans", name: "NguoiMua_ID", newName: "NguoiMuaId");
            RenameColumn(table: "dbo.HoaDonBans", name: "NhanVienBan_ID", newName: "NhanVienBanId");
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHang_ID", newName: "DonViBanHangId");
            DropPrimaryKey("dbo.CTHoaDons");
            AddColumn("dbo.HoaDonBans", "HTThanhToanId", c => c.Int(nullable: false));
            AddColumn("dbo.NguoiMuas", "DonViMuaHanhId", c => c.Int(nullable: false));
            AlterColumn("dbo.CTHoaDons", "HangHoaId", c => c.Int(nullable: false));
            AlterColumn("dbo.CTHoaDons", "HoaDonBanId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDonBans", "NguoiMuaId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDonBans", "NhanVienBanId", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVienBans", "DonViBanHangId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CTHoaDons", new[] { "HoaDonBanId", "HangHoaId" });
            CreateIndex("dbo.CTHoaDons", "HoaDonBanId");
            CreateIndex("dbo.CTHoaDons", "HangHoaId");
            CreateIndex("dbo.HoaDonBans", "NguoiMuaId");
            CreateIndex("dbo.HoaDonBans", "NhanVienBanId");
            CreateIndex("dbo.NhanVienBans", "DonViBanHangId");
            AddForeignKey("dbo.CTHoaDons", "HangHoaId", "dbo.HangHoas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CTHoaDons", "HoaDonBanId", "dbo.HoaDonBans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HoaDonBans", "NguoiMuaId", "dbo.NguoiMuas", "ID", cascadeDelete: true);
            AddForeignKey("dbo.HoaDonBans", "NhanVienBanId", "dbo.NhanVienBans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs", "ID", cascadeDelete: true);
            DropColumn("dbo.CTHoaDons", "IDHoaDonBan");
            DropColumn("dbo.CTHoaDons", "IDHangHoa");
            DropColumn("dbo.HoaDonBans", "IDHTThanhToan");
            DropColumn("dbo.HoaDonBans", "IDNguoiMua");
            DropColumn("dbo.HoaDonBans", "IDNhanVienBan");
            DropColumn("dbo.NguoiMuas", "IDDonViMuaHanh");
            DropColumn("dbo.NhanVienBans", "IDDonViBanHang");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanVienBans", "IDDonViBanHang", c => c.Int(nullable: false));
            AddColumn("dbo.NguoiMuas", "IDDonViMuaHanh", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNhanVienBan", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDNguoiMua", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonBans", "IDHTThanhToan", c => c.Int(nullable: false));
            AddColumn("dbo.CTHoaDons", "IDHangHoa", c => c.Int(nullable: false));
            AddColumn("dbo.CTHoaDons", "IDHoaDonBan", c => c.Int(nullable: false));
            DropForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs");
            DropForeignKey("dbo.HoaDonBans", "NhanVienBanId", "dbo.NhanVienBans");
            DropForeignKey("dbo.HoaDonBans", "NguoiMuaId", "dbo.NguoiMuas");
            DropForeignKey("dbo.CTHoaDons", "HoaDonBanId", "dbo.HoaDonBans");
            DropForeignKey("dbo.CTHoaDons", "HangHoaId", "dbo.HangHoas");
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHangId" });
            DropIndex("dbo.HoaDonBans", new[] { "NhanVienBanId" });
            DropIndex("dbo.HoaDonBans", new[] { "NguoiMuaId" });
            DropIndex("dbo.CTHoaDons", new[] { "HangHoaId" });
            DropIndex("dbo.CTHoaDons", new[] { "HoaDonBanId" });
            DropPrimaryKey("dbo.CTHoaDons");
            AlterColumn("dbo.NhanVienBans", "DonViBanHangId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "NhanVienBanId", c => c.Int());
            AlterColumn("dbo.HoaDonBans", "NguoiMuaId", c => c.Int());
            AlterColumn("dbo.CTHoaDons", "HoaDonBanId", c => c.Int());
            AlterColumn("dbo.CTHoaDons", "HangHoaId", c => c.Int());
            DropColumn("dbo.NguoiMuas", "DonViMuaHanhId");
            DropColumn("dbo.HoaDonBans", "HTThanhToanId");
            AddPrimaryKey("dbo.CTHoaDons", new[] { "IDHoaDonBan", "IDHangHoa" });
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHangId", newName: "DonViBanHang_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "NhanVienBanId", newName: "NhanVienBan_ID");
            RenameColumn(table: "dbo.HoaDonBans", name: "NguoiMuaId", newName: "NguoiMua_ID");
            RenameColumn(table: "dbo.CTHoaDons", name: "HoaDonBanId", newName: "HoaDonBan_ID");
            RenameColumn(table: "dbo.CTHoaDons", name: "HangHoaId", newName: "HangHoa_ID");
            CreateIndex("dbo.NhanVienBans", "DonViBanHang_ID");
            CreateIndex("dbo.HoaDonBans", "NhanVienBan_ID");
            CreateIndex("dbo.HoaDonBans", "NguoiMua_ID");
            CreateIndex("dbo.CTHoaDons", "HoaDonBan_ID");
            CreateIndex("dbo.CTHoaDons", "HangHoa_ID");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
            AddForeignKey("dbo.HoaDonBans", "NhanVienBan_ID", "dbo.NhanVienBans", "ID");
            AddForeignKey("dbo.HoaDonBans", "NguoiMua_ID", "dbo.NguoiMuas", "ID");
            AddForeignKey("dbo.CTHoaDons", "HoaDonBan_ID", "dbo.HoaDonBans", "ID");
            AddForeignKey("dbo.CTHoaDons", "HangHoa_ID", "dbo.HangHoas", "ID");
        }
    }
}
