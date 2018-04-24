using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    class CTHoaDon
    {
        [Key]
        [Column(Order =1)]
        public int IDHoaDonBan { get; set; }
        [Key]
        [Column(Order = 2)]
        public int IDHangHoa { get; set; }
        public  double ThanhTien { get; set; }
        public int SoLuongBan { get; set; }
        public virtual HoaDonBan HoaDonBan { get; set; }
        public virtual HangHoa HangHoa { get; set; }

    }
}
