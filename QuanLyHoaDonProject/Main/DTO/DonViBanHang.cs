using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO
{
    public class DonViBanHang
    {
        [Key]
        public int ID { get; set; }
        public int Logo { get; set; }
        [StringLengthAttribute(50)]
        public string Name { get; set; }
        public int MaSoThueBan { get; set; }
        [StringLengthAttribute(50)]
        public string DiaChi { get; set; }
        public int STKBan { get; set; }
        public int SDTBan { get; set; }
   
    }
}
