using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class HinhThucThanhToanBUS
    {
        QuanLyHoaDonContext htttDAO;
        public HinhThucThanhToanBUS()
        {
            htttDAO = new QuanLyHoaDonContext();
        }
        private Exception errorHTTTBUS;
        public List<HinhThucThanhToan>getAllListHTTT()
        {
            errorHTTTBUS = null;
            List<HinhThucThanhToan> httt = null;
            try
            {
                httt= htttDAO.HinhThucThanhToans.Where(x=>x.DaXoa==false).ToList();
            }
            catch (System.Exception ex)
            {
                errorHTTTBUS = ex;
            }
            return httt;
        }


    }
}
