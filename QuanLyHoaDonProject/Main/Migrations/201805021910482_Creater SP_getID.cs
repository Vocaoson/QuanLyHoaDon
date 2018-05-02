namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaterSP_getID : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("SP_GetIDHoaDonBan", @"SELECT IDENT_CURRENT('HoaDonBans')");
        }
        
        public override void Down()
        {
            DropStoredProcedure("SP_GetIDHoaDonBan");
        }
    }
}
