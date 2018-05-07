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
            return context.HangHoas.Where(item=> item.DaXoa == false).ToList();
        }
        public bool Add(HangHoa hangHoa)
        {
            context.HangHoas.Add(hangHoa);
            if(context.SaveChanges() <= 0)
            {
                return false;
            }      
            return true;
        }
        public bool Update(HangHoa hs)
        {
            var hangHoa = context.HangHoas.Find(hs.ID);
            hangHoa.Name = hs.Name;
            hangHoa.DVT = hs.DVT;
            hangHoa.SoLuong = hs.SoLuong;
            hangHoa.DonGiaBan = hs.DonGiaBan;
            hangHoa.DonGiaNhap = hs.DonGiaNhap;
            hangHoa.GhiChu = hs.GhiChu;
            hangHoa.DaXoa = hs.DaXoa;
            if(context.SaveChanges() <= 0)
            {
                return false;
            }
            return true;
        }
        public bool Delete(HangHoa hs)
        {
            var hangHoa = context.HangHoas.Find(hs.ID);
            hangHoa.DaXoa = true;
            if (context.SaveChanges() <= 0) return false;
            return true;
        }
        public List<HangHoa> FindByName(string name)
        {
            return context.HangHoas.Where(item => item.Name.Contains(name) && item.DaXoa == false).ToList();
        }
    }
}
