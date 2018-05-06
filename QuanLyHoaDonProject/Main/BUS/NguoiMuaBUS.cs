using Main.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.DTO;

namespace Main.BUS
{
    class NguoiMuaBUS
    {
        public NguoiMuaBUS()
        {
            nmDAO = new QuanLyHoaDonContext();
        }
        private QuanLyHoaDonContext nmDAO;
        public Exception ErrorNMBUS { get; set; }
        public object getIdByCMND(string cmnd)
        {
            ErrorNMBUS = null;
            try
            {
                var temp = nmDAO.NguoiMuas.Where(x => string.Compare(cmnd, x.CMND) == 0).Select(x=>x.ID).ToList();
                if (temp.Count>0)
                {
                    return temp[0];
                }
            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
            return null;
        }
        public bool checkCMND(string cmnd)
        {
            ErrorNMBUS = null;
            try
            {
                int temp = nmDAO.NguoiMuas.Count(x => string.Compare(cmnd, x.CMND) == 0);
                if (temp > 0)
                {
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
            return false;
        }
        public int checkCMND2(string cmnd)
        {
            ErrorNMBUS = null;
            try
            {
                return nmDAO.NguoiMuas.Where(x=>x.CMND==cmnd).SingleOrDefault().ID;

            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
            return -1;
        }

        public void insertNguoiMua(NguoiMua objectNM)
        {
            ErrorNMBUS = null;
            try
            {
                nmDAO.NguoiMuas.Add(objectNM);
                nmDAO.SaveChanges();
            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
        }

        public NguoiMua getNguoiMua(int nguoiMuaId)
        {
            ErrorNMBUS = null;
            try
            {
               return nmDAO.NguoiMuas.Find(nguoiMuaId);
               
            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
            return null;
        }

        public void updateNguoiMua()
        {
            ErrorNMBUS = null;
            try
            {
                nmDAO.SaveChanges();
            }
            catch (System.Exception ex)
            {
                ErrorNMBUS = ex;
            }
       
        }
    }
}
