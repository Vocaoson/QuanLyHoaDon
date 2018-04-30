using Main.DAO;
using Main.DTO;
using System;
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
               var temp = hdDAO.Database.SqlQuery<decimal>("EXEC SP_GetIDHoaDonBan").ToList();
                if (temp.Count > 0)
                {
                    return int.Parse(temp[0].ToString());
                }
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }

            return -1;

        }

        public List<HoaDonBan> getHoaDonBan()
        {
            errorHDBUS = null;

            List<HoaDonBan> hdb = null;
            try
            {
                hdb = hdDAO.HoaDonBans.Where(x=>x.DaXoa==false).ToList();
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return hdb;
        }
    }
}
