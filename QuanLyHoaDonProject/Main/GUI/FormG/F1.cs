using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Main.DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Main.DTO;

namespace Main.GUI.FormG
{
    public partial class F1 : XtraForm
    {
        QuanLyHoaDonContext db;
        public F1()
        {
            InitializeComponent();
            db = new QuanLyHoaDonContext();

        }
        // 
        //         private void F1_Load(object sender, EventArgs e)
        //         {
        //             ///Gán datasource
        //             gridUS1.Source = db.HinhThucThanhToans.ToList();
        //             ///map column
        //             gridUS1.MapColumn("ID", "Mã", true);
        //             gridUS1.MapColumn("Name", "Thanh Toán");
        //             ///Ẩn column
        //             gridUS1.VisibleColumn("HoaDonBans", false);
        //             ///Add column
        //             gridUS1.AddColumn("A", "ABC", true);
        // 
        // 
        //         }
        // 
        //         private void gridUS1_Load(object sender, EventArgs e)
        //         {
        //             gridUS1.FindClick += GridUS1_FindClick;
        //             gridUS1.RefeshClick += GridUS1_RefeshClick;
        //         }
        // 
        //         private void GridUS1_RefeshClick(object sender, EventArgs e)
        //         {
        //             gridUS1.ThongTinTimKiem = "";
        //             MessageBox.Show("Làm mới thành công", "Làm mới");
        // 
        //         }
        // 
        //         private void GridUS1_FindClick(object sender, EventArgs e)
        //         {
        //             string noidungtimkiem = gridUS1.ThongTinTimKiem;
        //             MessageBox.Show(noidungtimkiem, "Find");
        // 
        //         }
        // 
        //         private void simpleButton1_Click(object sender, EventArgs e)
        //         {
        //             if (gridUS1.IsSelected)
        //             {
        //                 var value = gridUS1.GetValueCell("ID");
        //                 ///Kiểm tra instan
        //                 string temp = "";
        //                 if (value != null)
        //                 {
        // 
        //                     foreach (var item in value)
        //                     {
        //                         temp += item + " ";
        //                     }
        //                 }
        //                 MessageBox.Show(string.Format("Select ID?\n{0}", temp), "Select");
        //                 gridUS1.HideColumnSelect();
        // 
        //             }
        //             else
        //             {
        //                 gridUS1.ShowColumnSelect();
        //             }
        //         }

        private void button1_Click(object sender, EventArgs e)
        {
            NguoiMua test = db.NguoiMuas.Find(21);//cmnd=252525252525
            test.CMND = (1234).ToString();
            var temp = db.NguoiMuas.ToList();//cmnd =1234
        }
    }
}