using Main.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.GUI
{
    public partial class frmProduct : Form
    {
        ProductBus productBus = new ProductBus();
        public frmProduct()
        {
            InitializeComponent();
            taskControl1.AddEvent += TaskControl1_AddEvent;
            taskControl1.SaveEvent += TaskControl1_SaveEvent;
            taskControl1.CalcelEvent += TaskControl1_CalcelEvent;
            taskControl1.EditEvent += TaskControl1_EditEvent;
            gridUS1.GridviewUS.RowClick += GridviewUS_RowClick;
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = true;
            txtProductName.Focus();
        }

        private void GridviewUS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            taskControl1.IsRowClick = true;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;
        }

        //when user click Add a product
        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = true;
            txtProductName.Focus();
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {
            gridUS1.Source = productBus.GetAll();
            gridUS1.MapColumn("ID", "Mã hàng hóa");
            gridUS1.MapColumn("Name", "Tên hàng hóa");
            gridUS1.MapColumn("DVT", "Đơn vị tính");
            gridUS1.MapColumn("SoLuong", "Số lượng");
            gridUS1.MapColumn("DonGiaNhap", "Đơn giá nhập");
            gridUS1.MapColumn("DonGiaBan", "Đơn giá bán");
            gridUS1.VisibleColumn("DaXoa", false);
            gridUS1.VisibleColumn("GhiChu", false);
        }

      

       
        public bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPriceSale.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceSale.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Focus();
                return false;
            }
            double temp;
            if (!double.TryParse(txtPriceBuy.Text,out temp))
            {
                MessageBox.Show("Đơn giá mua chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceBuy.Focus();
                return false;
            }
            if (!double.TryParse(txtPriceSale.Text, out temp))
            {
                MessageBox.Show("Đơn giá bán chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceSale.Focus();
                return false;
            }

            return true;
        }
    }
}
