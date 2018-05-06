using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class HangHoaBUS
    {

        public HangHoaBUS()
        {
            hhDAO = new QuanLyHoaDonContext();
        }
        QuanLyHoaDonContext hhDAO;
        private Exception errorHHBUS;

        public Exception ErrorHHBUS
        {
            get
            {
                return errorHHBUS;
            }

            set
            {
                errorHHBUS = value;
            }
        }

        public List<HangHoa> getAllHangHoa()
        {
            errorHHBUS = null;
            List<HangHoa> hh = null;
            hhDAO = new QuanLyHoaDonContext();
            try
            {
                hh = hhDAO.HangHoas.Where(x => x.DaXoa == false).ToList();
            }
            catch (System.Exception ex)
            {
                errorHHBUS = ex;
            }
            return hh;
        }

        public bool checkSoLuongKho(int idh, int slNhap)
        {
            errorHHBUS = null;
            try
            {
                var temp = hhDAO.HangHoas.Where(x => x.ID == idh).Select(x => x.SoLuong).ToList();
                if (temp.Count > 0)
                {
                    int slk = int.Parse(temp[0].ToString());
                    if (slNhap > slk)
                    {
                        return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                errorHHBUS = ex;
            }
            return true;
        }

        public HangHoa checkHangHoaKho(object iD)
        {
            try
            {
                HangHoa temp = hhDAO.HangHoas.Find(iD);
                return temp;
            }
            catch (System.Exception ex)
            {
                errorHHBUS = ex;
            }
            return null;
        }

        public void updateHangHoa(HangHoa temp)
        {
            try
            {
                hhDAO.SaveChanges();

            }
            catch (System.Exception ex)
            {
                errorHHBUS = ex;
            }

        }

        public HangHoa getHangHoaByID(int hangHoaId)
        {
            try
            {
                HangHoa temp = hhDAO.HangHoas.Find(hangHoaId);
                return temp;
            }
            catch (System.Exception ex)
            {
                errorHHBUS = ex;
            }
            return null;
        }
    }
}
