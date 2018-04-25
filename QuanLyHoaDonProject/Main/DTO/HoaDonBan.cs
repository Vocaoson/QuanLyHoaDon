using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class HoaDonBan
    {
        [Key]
        public int ID { get; set; }
        public double ThueSuat { get; set; }
        [StringLengthAttribute(50)]
        public string KyHieu { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayHD { get; set; }
        public int IDHTThanhToan { get; set; }
        public  virtual HinhThucThanhToan HinhThucThanhToan { get; set; }
        public int IDNguoiMua { get; set; }
        public virtual NguoiMua NguoiMua { get; set; }
        public int IDNhanVienBan { get; set; }
        public bool DaXoa { get; set; }

        public virtual NhanVienBan NhanVienBan { get; set; }


    }
}
