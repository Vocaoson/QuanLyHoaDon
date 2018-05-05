using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    public class NhanVienBan
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(100)]
        public string Name { get; set; }
        [StringLengthAttribute(20)]
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [StringLengthAttribute(100)]
        public string TTLamViec { get; set; }
        [StringLengthAttribute(255)]
        public string HinhAnh { get; set; }
        [StringLengthAttribute(255)]
        public string DiaChi { get; set; }
        [StringLengthAttribute(100)]
        public string CMND { get; set; }
        [DataType(DataType.Date)]
        public DateTime? NgayCap { get; set; }
        [StringLengthAttribute(100)]
        public string NoiCap { get; set; }
        public bool DaXoa { get; set; }
        public bool? HonNhan { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
