namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CTHoaDons", "dsad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CTHoaDons", "dsad", c => c.Int(nullable: false));
        }
    }
}
