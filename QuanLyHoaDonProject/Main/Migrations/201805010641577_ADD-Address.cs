namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanVienBans", "DiaChi", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanVienBans", "DiaChi");
        }
    }
}
