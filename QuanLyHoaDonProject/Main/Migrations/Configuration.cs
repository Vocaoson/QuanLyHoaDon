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
           context.HinhThucThanhToans.AddOrUpdate(p=>p.ID,new DTO.HinhThucThanhToan() { ID = 1, Name = "Tiền Mặt",DaXoa=false }, new DTO.HinhThucThanhToan() { ID = 2, Name = "Chuyển Khoản", DaXoa = false }, new DTO.HinhThucThanhToan() { ID = 3, Name = "Tiền Mặt/ Chuyển Khoản", DaXoa = false });
        }
    }
}
