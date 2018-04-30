using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class NhanVienBanBUS
    {
        public NhanVienBanBUS()
        {
            nvbDAO = new QuanLyHoaDonContext();
        }
        private QuanLyHoaDonContext nvbDAO;
        private Exception errorNVBBUS;

        public Exception ErrorNVBBUS
        {
            get
            {
                return errorNVBBUS;
            }

            set
            {
                errorNVBBUS = value;
            }
        }
        public List<NhanVienBan> getAllNhanVienBan()
        {
            errorNVBBUS = null;
            List<NhanVienBan> nvb = null;
            try
            {
                nvb = nvbDAO.NhanVienBans.Where(x => x.DaXoa == false).ToList();
            }
            catch (Exception ex)
            {
                errorNVBBUS = ex;
            }
            return nvb;
        }

    }
}
