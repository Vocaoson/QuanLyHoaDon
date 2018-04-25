namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumDaXoaNhanVienBan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanVienBans", "DaXoa", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanVienBans", "DaXoa");
        }
    }
}
