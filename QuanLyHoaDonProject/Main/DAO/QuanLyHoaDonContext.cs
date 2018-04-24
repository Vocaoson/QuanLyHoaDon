using Main.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DAO
{
    class QuanLyHoaDonContext:DbContext
    {
        public QuanLyHoaDonContext():base("QuanLyHoaDonConnectionString")
        {

        }
        public DbSet<DonViBanHang> DonViBanHangs { get; set; }
        public DbSet<DonViMuaHang> DonViMuaHangs { get; set; }

        public DbSet<HangHoa> HangHoas { get; set; }

        public DbSet<HinhThucThanhToan> HinhThucThanhToans { get; set; }

        public DbSet<HoaDonBan> HoaDonBans { get; set; }

        public DbSet<NguoiMua> NguoiMuas { get; set; }

        public DbSet<NhanVienBan> NhanVienBans { get; set; }
        public DbSet<CTHoaDon> CTHoaDons { get; set; }



    }
}
