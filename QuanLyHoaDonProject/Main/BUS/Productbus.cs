using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    public class ProductBus
    {
        QuanLyHoaDonContext context = new QuanLyHoaDonContext();
        public List<HangHoa> GetAll()
        {
            try
            {
                return context.HangHoas.Where(item => item.DaXoa == false).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        public bool Add(HangHoa hangHoa)
        {

            try
            {
                context.HangHoas.Add(hangHoa);
                if (context.SaveChanges() <= 0)
                {
                    return false;
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(HangHoa hs)
        { 
            try
            {
                var hangHoa = context.HangHoas.Find(hs.ID);
                hangHoa.Name = hs.Name;
                hangHoa.DVT = hs.DVT;
                hangHoa.SoLuong = hs.SoLuong;
                hangHoa.DonGiaBan = hs.DonGiaBan;
                hangHoa.DonGiaNhap = hs.DonGiaNhap;
                hangHoa.GhiChu = hs.GhiChu;
                hangHoa.DaXoa = hs.DaXoa;
                if (context.SaveChanges() <= 0)
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(HangHoa hs)
        {
            try
            {
                var hangHoa = context.HangHoas.Find(hs.ID);
                hangHoa.DaXoa = true;
                if (context.SaveChanges() <= 0) return false;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public List<HangHoa> FindByName(string name)
        {
            try
            {
                return context.HangHoas.Where(item => item.Name.Contains(name) && item.DaXoa == false).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }

        }
    }
}
