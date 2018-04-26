namespace Main.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Main.DAO.QuanLyHoaDonContext>
    { 
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Main.DAO.QuanLyHoaDonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           context.HinhThucThanhToans.AddOrUpdate(new DTO.HinhThucThanhToan() { Name = "Tiền Mặt" }, new DTO.HinhThucThanhToan() { Name = "Chuyển Khoản" }, new DTO.HinhThucThanhToan() { Name = "Tiền Mặt/ Chuyển Khoản" });
        }
    }
}
