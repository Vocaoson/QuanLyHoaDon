namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdittypeSTKNguoiMua : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonViMuaHangs", "STKMua", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonViMuaHangs", "STKMua", c => c.Int(nullable: false));
        }
    }
}
