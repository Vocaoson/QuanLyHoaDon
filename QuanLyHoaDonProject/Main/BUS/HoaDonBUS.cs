using Main.DAO;
using Main.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class HoaDonBUS
    {
        QuanLyHoaDonContext hdDAO;
        public HoaDonBUS()
        {
            hdDAO = new QuanLyHoaDonContext();
        }
        private Exception errorHDBUS;

        public Exception ErrorHDBUS
        {
            get
            {
                return errorHDBUS;
            }

            set
            {
                errorHDBUS = value;
            }
        }
        public int getIDHDB()
        {
            errorHDBUS = null;

            try
            {
                var temp = hdDAO.Database.SqlQuery<decimal>(@"SELECT IDENT_CURRENT('HoaDonBans')").ToList();
                if (temp.Count > 0)
                {
                    int id = int.Parse(temp[0].ToString());
                    if (id == 1 && hdDAO.HoaDonBans.ToList().Count == 0)
                    {
                        return id;
                    }
                    else
                    {
                        return id + 1;
                    }

                }
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }

            return -1;

        }
        public void insertHoaDonBan(HoaDonBan hdb)
        {
            errorHDBUS = null;
            try
            {
                hdDAO.HoaDonBans.Add(hdb);
                hdDAO.SaveChanges();
            }
            catch (Exception ex)
            {

                errorHDBUS = ex;
            }
        }

        public List<object> getHoaDonBan()
        {
            errorHDBUS = null;
            try
            {
                var temp = hdDAO.HoaDonBans.AsEnumerable().Where(x => x.DaXoa == false).Select(x => 
                new { ID = x.ID, KyHieu = x.KyHieu,NgayHD=x.NgayHD,TongTienSo=int.Parse(x.TongTienSo)  , }).ToList();
                return temp.Cast<object>().ToList();
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return null;
        }

        public bool removeHoaDon(int idhoadon)
        {
            errorHDBUS = null;
            try
            {
                hdDAO.HoaDonBans.Remove(hdDAO.HoaDonBans.Find(idhoadon));
                return true;
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return false;
        }
    }
}
