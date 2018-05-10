using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    public class ProgramBUS
    {
        DAO.QuanLyHoaDonContext context = new DAO.QuanLyHoaDonContext();
        public bool AddDefaultHTTT(string name)
        {
            try
            {
                context.HinhThucThanhToans.Add(new DTO.HinhThucThanhToan() { Name = name,DaXoa = false });
                if(context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool AddDefaultAccount(string name,string pass)
        {
            try
            {
                context.DangNhaps.Add(new DTO.DangNhap() { TenDangNhap = name,PassWord = pass });
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int CountHTTT()
        {
            return context.HinhThucThanhToans.Count();
        }
    }
}
