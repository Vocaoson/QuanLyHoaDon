using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class DonViBanHang
    {
        [Key]
        public int ID { get; set; }
        public int Logo { get; set; }
        [StringLengthAttribute(50)]
        public string Name { get; set; }
        public int MaSoThueMua { get; set; }
        [StringLengthAttribute(50)]
        public string DiaChi { get; set; }
        public int STKBan { get; set; }
        public int SDTBan { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
        public virtual ICollection<NhanVienBan> NhanVienBans { get; set; }
    }
}
