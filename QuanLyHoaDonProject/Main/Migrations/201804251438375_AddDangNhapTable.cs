namespace Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDangNhapTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangNhaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(maxLength: 100),
                        PassWord = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DangNhaps");
        }
    }
}
