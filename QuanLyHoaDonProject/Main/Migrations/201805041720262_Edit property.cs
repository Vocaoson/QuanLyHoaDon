namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editproperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVienBans", "SDT", c => c.String());
            AlterColumn("dbo.NhanVienBans", "CMND", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVienBans", "CMND", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVienBans", "SDT", c => c.Int(nullable: false));
        }
    }
}
