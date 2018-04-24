using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class DonViMuaHang
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(50)]
        public string Name { get; set; }
        [StringLengthAttribute(50)]
        public string DiaChiMua { get; set; }

        public int MaSoThueMua { get; set; }

        public int STKMua { get; set; }

        public int SDTMua { get; set; }
        public virtual ICollection<NguoiMua> NguoiMuas { get; set; }


    }
}
