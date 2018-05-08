using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    class DonViBanHangBUS
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
        public DonViBanHang GetDVMH()
        {
            error = null;
            try
            {
                var list = context.DonViBanHangs.ToList();
                return list[0];
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        public bool Update(DonViBanHang donVi)
        {
            error = null;
            try
            {
                var dv = context.DonViBanHangs.Find(donVi.ID);
                dv.Name = donVi.Name;
                dv.MaSoThueBan = donVi.MaSoThueBan;
                dv.DiaChi = donVi.DiaChi;
                dv.STKBan = donVi.STKBan;
                dv.SDTBan = donVi.SDTBan;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
    }
}
