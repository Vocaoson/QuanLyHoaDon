namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaterDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonViBanHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DonViMuaHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HangHoas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HinhThucThanhToans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HoaDonBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NguoiMuas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NhanVienBans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanVienBans");
            DropTable("dbo.NguoiMuas");
            DropTable("dbo.HoaDonBans");
            DropTable("dbo.HinhThucThanhToans");
            DropTable("dbo.HangHoas");
            DropTable("dbo.DonViMuaHangs");
            DropTable("dbo.DonViBanHangs");
        }
    }
}
