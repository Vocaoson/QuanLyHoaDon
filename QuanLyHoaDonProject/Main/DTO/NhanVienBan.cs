using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class NhanVienBan
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(100)]
        public string Name { get; set; }
        [StringLengthAttribute(20)]
        public string GioiTinh { get; set; }
        public int SDT { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [StringLengthAttribute(100)]
        public string TTLamViec { get; set; }
        public int HinhAnh { get; set; }
        public int CMND { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayCap { get; set; }
        [StringLengthAttribute(100)]
        public string NoiCap { get; set; }
        public bool DaXoa { get; set; }

        public int IDDonViBanHang { get; set; }
        public virtual DonViBanHang DonViBanHang { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
