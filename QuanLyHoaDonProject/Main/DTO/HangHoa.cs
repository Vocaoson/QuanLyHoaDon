using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class HangHoa
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(100)]
        public string Name { get; set; }
        [StringLengthAttribute(50)]

        public string DVT { get; set; }
        public int SoLuong { get; set; }
        public double DonGiaNhap { get; set; }
        public double DonGiaBan { get; set; }
        [StringLengthAttribute(250)]

        public string GhiChu { get; set; }
        public int IDDonViBanHang { get; set; }
        public bool DaXoa { get; set; }

        public virtual DonViBanHang DonViBanHang { get; set; }



    }
}
