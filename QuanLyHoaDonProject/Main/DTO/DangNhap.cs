using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Main.DTO
{
    public class DangNhap
    {
        [Key]
        public int ID { get; set; }
        [StringLengthAttribute(100)]
        public string TenDangNhap { get; set; }
        public string PassWord { get; set; }
    }
}
