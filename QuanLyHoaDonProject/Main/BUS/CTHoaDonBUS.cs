using Main.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.DTO;

namespace Main.BUS
{
    class CTHoaDonBUS
    {
        public CTHoaDonBUS()
        {
            cthdDAO = new QuanLyHoaDonContext();
        }
        private QuanLyHoaDonContext cthdDAO;
         public Exception ErrorCTHDBUS{get;set ;}

        public void insertCTHD(CTHoaDon ct)
        {
            ErrorCTHDBUS = null;
            try
            {
                cthdDAO.CTHoaDons.Add(ct);
                cthdDAO.SaveChanges();
            }
            catch (System.Exception ex)
            {
                ErrorCTHDBUS = ex;
            }
        }
    }
}
