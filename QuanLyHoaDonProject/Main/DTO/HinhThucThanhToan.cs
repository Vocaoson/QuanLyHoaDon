using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    public class HinhThucThanhToan
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(100)]
        public string Name { get; set; }
        public bool DaXoa { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
