namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edittypedonvimuadvb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonViMuaHangs", "SDTMua", c => c.String());
            AlterColumn("dbo.DonViBanHangs", "STKBan", c => c.String());
            AlterColumn("dbo.DonViBanHangs", "SDTBan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonViBanHangs", "SDTBan", c => c.Int(nullable: false));
            AlterColumn("dbo.DonViBanHangs", "STKBan", c => c.Int(nullable: false));
            AlterColumn("dbo.DonViMuaHangs", "SDTMua", c => c.Int(nullable: false));
        }
    }
}
