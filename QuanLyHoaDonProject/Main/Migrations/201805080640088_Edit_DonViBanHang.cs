namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_DonViBanHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonViBanHangs", "MaSoThueBan", c => c.String());
            DropColumn("dbo.DonViBanHangs", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonViBanHangs", "Logo", c => c.Int(nullable: false));
            AlterColumn("dbo.DonViBanHangs", "MaSoThueBan", c => c.Int(nullable: false));
        }
    }
}
