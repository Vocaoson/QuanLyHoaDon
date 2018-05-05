namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNhanVienBan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVienBans", "NgayCap", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVienBans", "NgayCap", c => c.DateTime(nullable: false));
        }
    }
}
