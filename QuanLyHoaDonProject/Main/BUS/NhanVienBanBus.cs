using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    public class NhanVienBanBUS
    {
        QuanLyHoaDonContext context = new QuanLyHoaDonContext();
        public List<NhanVienBan> GetAll()
        {
            try
            {
                return context.NhanVienBans.Where(item => item.DaXoa == false).ToList();
            }
            catch
            {
                return null;
            }   
        }
        public bool Add(NhanVienBan nhanVien)
        {
            try
            {
                context.NhanVienBans.Add(nhanVien);
                if (context.SaveChanges() <= 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool Update(NhanVienBan nhanVien)
        {
            try
            {
                var nv = context.NhanVienBans.Find(nhanVien.ID);
                nv.Name = nhanVien.Name;
                nv.CMND = nhanVien.CMND;
                nv.DOB = nhanVien.DOB;
                nv.GioiTinh = nhanVien.GioiTinh;
                nv.HinhAnh = nhanVien.HinhAnh;
                nv.NoiCap = nhanVien.NoiCap;
                nv.NgayCap = nhanVien.NgayCap;
                nv.TTLamViec = nhanVien.TTLamViec;
                nv.SDT = nhanVien.SDT;
                nv.HonNhan = nhanVien.HonNhan;
                if (context.SaveChanges() <= 0)
                {
                    return false;
                }
                return true;

            }
            catch
            {
                return false;
            }
        
        }
        public bool Delete(NhanVienBan nv)
        {
            try
            {
                var nhanVien = context.NhanVienBans.Find(nv.ID);
                nhanVien.DaXoa = true;
                if (context.SaveChanges() <= 0) return false;
                return true;
            }
            catch
            {
                return false;
            }
         
        }
        public List<NhanVienBan > FindByName(string name)
        {
            try
            {
                return context.NhanVienBans.Where(item => item.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
