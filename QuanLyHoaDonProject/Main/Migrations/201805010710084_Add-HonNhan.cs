namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHonNhan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanVienBans", "HonNhan", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanVienBans", "HonNhan");
        }
    }
}
