namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNhanVienBan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs");
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHangId" });
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHangId", newName: "DonViBanHang_ID");
            AlterColumn("dbo.NhanVienBans", "DonViBanHang_ID", c => c.Int());
            CreateIndex("dbo.NhanVienBans", "DonViBanHang_ID");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVienBans", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropIndex("dbo.NhanVienBans", new[] { "DonViBanHang_ID" });
            AlterColumn("dbo.NhanVienBans", "DonViBanHang_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.NhanVienBans", name: "DonViBanHang_ID", newName: "DonViBanHangId");
            CreateIndex("dbo.NhanVienBans", "DonViBanHangId");
            AddForeignKey("dbo.NhanVienBans", "DonViBanHangId", "dbo.DonViBanHangs", "ID", cascadeDelete: true);
        }
    }
}
