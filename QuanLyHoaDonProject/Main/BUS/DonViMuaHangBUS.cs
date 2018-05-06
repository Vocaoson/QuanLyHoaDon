using Main.DAO;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
   public class DonViMuaHangBUS
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

        public List<DonViMuaHang> GetAll()
        {
            error = null;
            try
            {
                return context.DonViMuaHangs.ToList();
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        public bool Add(DonViMuaHang donVi)
        {
            error = null;
            try
            {
                context.DonViMuaHangs.Add(donVi);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public List<DonViMuaHang> Search(string name)
        {
            error = null;
            try
            {
                var result = from m in context.DonViMuaHangs
                             where m.Name.Contains(name)
                             select m;
                return result.ToList();
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        public bool Update(DonViMuaHang donVi)
        {
            error = null;
            try
            {
                var dv = context.DonViMuaHangs.Find(donVi.ID);
                dv.Name = donVi.Name;
                dv.MaSoThueMua = donVi.MaSoThueMua;
                dv.SDTMua = donVi.SDTMua;
                dv.STKMua = donVi.STKMua;
                dv.DiaChiMua = donVi.DiaChiMua;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public bool Delete(int id)
        {
            error = null;
            try
            {
                var dv = context.DonViMuaHangs.Find(id);
                context.DonViMuaHangs.Remove(dv);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
		}
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
