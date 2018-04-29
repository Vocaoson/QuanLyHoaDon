namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditHangHoaDonViBan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs");
            DropIndex("dbo.HangHoas", new[] { "DonViBanHang_ID" });
            DropColumn("dbo.HangHoas", "IDDonViBanHang");
            DropColumn("dbo.HangHoas", "DonViBanHang_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HangHoas", "DonViBanHang_ID", c => c.Int());
            AddColumn("dbo.HangHoas", "IDDonViBanHang", c => c.Int(nullable: false));
            CreateIndex("dbo.HangHoas", "DonViBanHang_ID");
            AddForeignKey("dbo.HangHoas", "DonViBanHang_ID", "dbo.DonViBanHangs", "ID");
        }
    }
}
