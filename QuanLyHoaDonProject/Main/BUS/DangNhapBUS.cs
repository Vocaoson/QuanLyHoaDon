using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class DangNhapBUS
    {
        QuanLyHoaDonContext context = new QuanLyHoaDonContext();
        private Exception error;

        public Exception Error
        {
            get
            {
                return error;
            }
        }
        public bool TestAccount(DangNhap dangnhap)
        {
            error = null;
            try
            {
                List<DangNhap> list = context.DangNhaps.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TenDangNhap.Equals(dangnhap.TenDangNhap) && list[i].PassWord.Equals(dangnhap.PassWord)) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
    }
}
