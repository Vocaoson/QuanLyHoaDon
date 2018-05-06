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
using DevExpress.XtraGrid.Views.Grid;

namespace Main.GUI.GridUS
{
    public partial class FormExampleGrid : DevExpress.XtraEditors.XtraForm
    {
        QuanLyHoaDonContext db;
        public FormExampleGrid()
        {
            InitializeComponent();
            db = new QuanLyHoaDonContext();
        }


        private void GridUS1_RefeshClick(object sender, EventArgs e)
        {
            gridUS1.ThongTinTimKiem = "";
            MessageBox.Show("Làm mới thành công", "Làm mới");

        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            string noidungtimkiem = gridUS1.ThongTinTimKiem;
            MessageBox.Show(noidungtimkiem, "Find");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridUS1.IsSelected)
            {
                var value = gridUS1.GetValueCell("ID");
                ///Kiểm tra instan
                string temp = "";
                if (value != null)
                {

                    foreach (var item in value)
                    {
                        temp += item + " ";
                    }
                }
                MessageBox.Show(string.Format("Select ID?\n{0}", temp), "Select");
                gridUS1.HideColumnSelect();

            }
            else
            {
                gridUS1.ShowColumnSelect();
            }
        }

        private void FormExampleGrid_Load(object sender, EventArgs e)
        {
            ///Gán datasource
            gridUS1.Source = db.HinhThucThanhToans.ToList();
            ///map column
            gridUS1.MapColumn("ID", "Mã", true);
            gridUS1.MapColumn("Name", "Thanh Toán");
            ///Ẩn column
            gridUS1.VisibleColumn("HoaDonBans", false);
            ///Add column
            gridUS1.AddColumn("A", "ABC", true);
        }

        private void gridUS1_Load(object sender, EventArgs e)
        {
            gridUS1.FindClick += GridUS1_FindClick;
            gridUS1.RefeshClick += GridUS1_RefeshClick;
            gridUS1.GridviewUS.Click += GridviewUS_Click;
        }

        private void GridviewUS_Click(object sender, EventArgs e)
        {
            GridView temp = sender as GridView;
            MessageBox.Show(String.Format("Row Select:{0}",temp.GetSelectedRows()[0]));
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}