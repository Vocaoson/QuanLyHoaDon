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
            return context.HangHoas.ToList();
        }
        public bool Add(HangHoa hangHoa)
        {
            if(context.HangHoas.Add(hangHoa) == null)
            {
                return false;
            }
            return true;
        }
    }
}
