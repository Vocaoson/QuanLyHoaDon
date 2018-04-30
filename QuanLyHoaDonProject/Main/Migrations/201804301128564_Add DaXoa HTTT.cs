namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDaXoaHTTT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HinhThucThanhToans", "DaXoa", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HinhThucThanhToans", "DaXoa");
        }
    }
}
