using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class DonViMuaHangBUS
    {
        public DonViMuaHangBUS()
        {
            dvmhDAO = new QuanLyHoaDonContext();
        }
        private QuanLyHoaDonContext dvmhDAO;
        private Exception errorDVMHBUS;

        public Exception ErrorDVMHBUS
        {
            get
            {
                return errorDVMHBUS;
            }

            set
            {
                errorDVMHBUS = value;
            }
        }
        public List<DonViMuaHang>getAllDonViMuaHang()
        {
            errorDVMHBUS = null;
            List<DonViMuaHang> dvmh = null;
            try
            {
                dvmh = dvmhDAO.DonViMuaHangs.ToList();
            }
            catch (System.Exception ex)
            {
                errorDVMHBUS = ex;
            }
            return dvmh;
        }
    }
}
