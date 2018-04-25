namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDaXoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HangHoas", "DaXoa", c => c.Boolean(nullable: false));
            AddColumn("dbo.HoaDonBans", "DaXoa", c => c.Boolean(nullable: false));
            AddColumn("dbo.NguoiMuas", "DaXoa", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiMuas", "DaXoa");
            DropColumn("dbo.HoaDonBans", "DaXoa");
            DropColumn("dbo.HangHoas", "DaXoa");
        }
    }
}
