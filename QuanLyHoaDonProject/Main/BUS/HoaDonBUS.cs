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
<<<<<<< HEAD
                var temp = hdDAO.HoaDonBans.AsEnumerable().Where(x => x.DaXoa == false).Select(x =>
                new { ID = x.ID, KyHieu = x.KyHieu, NgayHD = x.NgayHD, TongTienSo = double.Parse(x.TongTienSo), }).ToList();
||||||| merged common ancestors
                var temp = hdDAO.HoaDonBans.AsEnumerable().Where(x => x.DaXoa == false).Select(x => 
                new { ID = x.ID, KyHieu = x.KyHieu,NgayHD=x.NgayHD,TongTienSo=int.Parse(x.TongTienSo)  , }).ToList();
=======
                var temp = hdDAO.HoaDonBans.AsEnumerable().Where(x => x.DaXoa == false).Select(x => 
                new { ID = x.ID, KyHieu = x.KyHieu,NgayHD=x.NgayHD,TongTienSo=x.TongTienSo.toDoubleString()  , }).ToList();
>>>>>>> 38885b7634b05f0307875c63169e6ec6e3d40966
                return temp.Cast<object>().ToList();
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return null;
        }
        public List<object> GetByDate(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var rs = hdDAO.HoaDonBans
   .Join(hdDAO.DonViMuaHangs,
      hd => hd.ID,
      dvmh => dvmh.ID,
      (hd, dvmh) => new
      {
          HoaDon = hd,
          DVMH = dvmh
      })
   .Where(item => item.HoaDon.NgayHD >= dateFrom && item.HoaDon.NgayHD <= dateTo).Select(item => new
   {
       ID = item.HoaDon.ID,
       KiHieu = item.HoaDon.KyHieu,
       MaKhachHang = item.DVMH.Name,
       TenDonViMua = item.DVMH.Name,
       MaSoThue = item.DVMH.MaSoThueMua,
       DiaChi = item.DVMH.DiaChiMua,
       STK = item.DVMH.SDTMua,
       NgayXuat = item.HoaDon.NgayHD,
       HinhThuc = item.HoaDon.HinhThucThanhToan,
       ThanhTien = item.HoaDon.TongTienSo
   }).ToList();    // where statement
                return rs.Cast<object>().ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<object> GetHoaDonByDonViMua(int id)
        {
            try
            {
                var rs = hdDAO.HoaDonBans
   .Join(hdDAO.DonViMuaHangs,
      hd => hd.ID,
      dvmh => dvmh.ID,
      (hd, dvmh) => new
      {
          HoaDon = hd,
          DVMH = dvmh
      })
   .Where(item => item.DVMH.ID == id).Select(item => new
   {
       ID = item.HoaDon.ID,
       KiHieu = item.HoaDon.KyHieu,
       MaKhachHang = item.DVMH.Name,
       TenDonViMua = item.DVMH.Name,
       MaSoThue = item.DVMH.MaSoThueMua,
       DiaChi = item.DVMH.DiaChiMua,
       STK = item.DVMH.SDTMua,
       NgayXuat = item.HoaDon.NgayHD,
       HinhThuc = item.HoaDon.HinhThucThanhToan,
       ThanhTien = item.HoaDon.TongTienSo
   }).ToList();    // where statement
                return rs.Cast<object>().ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<object> getHoaDonByFind(string noidungtimkiem)
        {
            errorHDBUS = null;
            try
            {
                int test;
                bool kq = int.TryParse(noidungtimkiem, out test);
                if (!kq)
                {
                    test = -1;
                }
                var temp = hdDAO.HoaDonBans.AsEnumerable().Where(hd => hd.ID == test ||
                                                 hd.ThueSuat == test ||
                                                 hd.KyHieu.Contains(noidungtimkiem) ||
                                                 hd.TongTienSo.Contains(noidungtimkiem) ||
                                                 hd.TongTienChu.Contains(noidungtimkiem)
                                                 ).Select(x =>
                new { ID = x.ID, KyHieu = x.KyHieu, NgayHD = x.NgayHD, TongTienSo = int.Parse(x.TongTienSo), }).ToList();
                return temp.Cast<object>().ToList();
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return null;
        }

        public HoaDonBan findHoaDon(int iD)
        {
            errorHDBUS = null;
            try
            {
                return hdDAO.HoaDonBans.Find(iD);

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

        public void updateHoaDon()
        {
            errorHDBUS = null;
            try
            {
                hdDAO.SaveChanges();
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }

        }

        public bool deleteHoaDon(int idhoadon)
        {
            ErrorHDBUS = null;
            try
            {
                hdDAO.HoaDonBans.RemoveRange(hdDAO.HoaDonBans.Where(x => x.ID == idhoadon));
                hdDAO.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                errorHDBUS = ex;
            }
            return false;

        }

        public bool deleteListHoaDonBUS(List<object> id)
        {
            if (id.Count > 0)
            {
                for (int i = 0; i < id.Count; i++)
                {
                    bool kq = deleteHoaDon(id[i].toInt());
                    if (kq == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
