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
            context.HinhThucThanhToans.AddOrUpdate(p => p.ID, new DTO.HinhThucThanhToan() { ID = 1, Name = "Tiền Mặt" }
                                                        , new DTO.HinhThucThanhToan() { ID = 2, Name = "Chuyển Khoản" }
                                                        , new DTO.HinhThucThanhToan() { ID = 3, Name = "Tiền Mặt/ Chuyển Khoản" });
            context.DonViMuaHangs.AddOrUpdate(m => m.ID, new DTO.DonViMuaHang() {ID=1, Name="DVM 1", DiaChiMua="12/12/23 An dương vương", MaSoThueMua=01245678, STKMua=(124548451254).ToString(), SDTMua=(0123456789).ToString(), });
            context.DonViBanHangs.AddOrUpdate(m => m.ID, new DTO.DonViBanHang() { ID = 1, Name = "DV1", Logo = 0, MaSoThueBan = 123, DiaChi = "51/2/5 Hùng Vương", STKBan = (987654321).ToString(), SDTBan = (98745612314).ToString(), });
            context.NhanVienBans.AddOrUpdate(m => m.ID, new DTO.NhanVienBan() { ID =1, Name ="Nhân Viên 1", GioiTinh ="Nữ", SDT =(01633185547).ToString(), DOB =new DateTime(1997,12,2), TTLamViec ="Còn làm", HinhAnh =0, CMND =(4542125455).ToString(), NgayCap =new DateTime(2010,10,23), NoiCap ="TP Hcm", DaXoa =false, });
            context.HangHoas.AddOrUpdate(x => x.ID, new DTO.HangHoa() { ID = 1, Name = "PS", DVT = "Típ", SoLuong = 30, DonGiaNhap = 10000, DonGiaBan = 11000, GhiChu = "Kem đánh răng", DaXoa = false, },
                new DTO.HangHoa() { ID = 2, Name = "Conrgat", DVT = "Típ", SoLuong = 10, DonGiaNhap = 11000, DonGiaBan = 12000, GhiChu = "Kem đánh răng", DaXoa = false, },
                new DTO.HangHoa() { ID = 3, Name = "CloseUp", DVT = "Típ", SoLuong = 20, DonGiaNhap = 12000, DonGiaBan = 13000, GhiChu = "Kem đánh răng", DaXoa = false, }

            );
        }
    }
}
