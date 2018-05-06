namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_DonViNguoiMua : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonViMuaHangs", "STKMua", c => c.String(maxLength: 20));
            AlterColumn("dbo.DonViMuaHangs", "SDTMua", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonViMuaHangs", "SDTMua", c => c.Int(nullable: false));
            AlterColumn("dbo.DonViMuaHangs", "STKMua", c => c.Int(nullable: false));
        }
    }
}
