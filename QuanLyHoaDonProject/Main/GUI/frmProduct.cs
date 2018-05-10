using Main.BUS;
using Main.DTO;
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
        bool isAdd = true;
        bool isFind = false;
        public frmProduct()
        {
            InitializeComponent();
            taskControl1.AddEvent += TaskControl1_AddEvent;
            taskControl1.SaveEvent += TaskControl1_SaveEvent;
            taskControl1.CalcelEvent += TaskControl1_CalcelEvent;
            taskControl1.EditEvent += TaskControl1_EditEvent;
            taskControl1.DeleteEvent += TaskControl1_DeleteEvent;
            gridUS1.GridviewUS.RowClick += GridviewUS_RowClick;
            gridUS1.FindClick += GridUS1_FindClick;
            gridUS1.RefeshClick += GridUS1_RefeshClick;
        }

        private void GridUS1_RefeshClick(object sender, EventArgs e)
        {
            isFind = false;
            gridUS1.ThongTinTimKiem = "";
            LoadAll();
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            isFind = true;
            LoadAll();
        }
        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            var hs = new HangHoa() { ID = int.Parse(txtProductId.Text) };
            if (productBus.Delete(hs))
            {
                MessageBox.Show("Xóa hàng hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
                return;
            }
            MessageBox.Show("Xóa hàng hóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = true;
            txtProductName.Focus();
            isAdd = false;
        }

        private void GridviewUS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            taskControl1.IsRowClick = true;
            panelContent.Enabled = false;
            Bind();
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;

        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            isFind = false;
            if (!inputIsCorrect()) return;
            taskControl1.isSuccessFul = true;
            var hangHoa = new HangHoa()
            {
                Name = txtProductName.Text,
                DVT = txtUnit.Text,
                SoLuong = int.Parse(nbNumber.Value.ToString()),
                DonGiaNhap = double.Parse(txtPriceBuy.Text),
                DonGiaBan = double.Parse(txtPriceSale.Text),
                GhiChu = txtNote.Text,
                DaXoa = false
            };
            if (isAdd)
            {
                var rs = productBus.Add(hangHoa);
                if (rs == true)
                {
                    MessageBox.Show("Thêm hàng hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();
  
                }
                else
                {
                    MessageBox.Show("Thêm hàng hóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                hangHoa.ID = int.Parse(txtProductId.Text);
                var rs = productBus.Update(hangHoa);
                if (rs == false)
                {
                    MessageBox.Show("Sửa hóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa hàng hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            panelContent.Enabled = false;
        }

        //when user click Add a product
        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            panelContent.Enabled = true;
            txtProductName.Focus();
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadAll();
        }
        private void LoadAll()
        {
            gridUS1.Source = null;
            if (isFind)
            {
                var rs = productBus.FindByName(gridUS1.ThongTinTimKiem);
                if(rs == null)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                }
                if(rs.Count == 0)
                {
                    return;
                }
                gridUS1.Source = rs;
            }
            else
            {
                var rs = productBus.GetAll();
                if (rs == null)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (rs.Count == 0)
                {
                    return;
                }
                gridUS1.Source = rs;
            }
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
            taskControl1.isSuccessFul = false;
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
            if(nbNumber.Value <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbNumber.Focus();
                return false;
            }
            double temp;
            if (!double.TryParse(txtPriceBuy.Text, out temp) || temp <= 0)
            {
                MessageBox.Show("Đơn giá mua chỉ có thể là số dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceBuy.Focus();
                return false;
            }
            if (!double.TryParse(txtPriceSale.Text, out temp) || temp <= 0)
            {
                MessageBox.Show("Đơn giá bán chỉ có thể là số dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceSale.Focus();
                return false;
            }
            return true;
        }

        public void Bind()
        {
            var current = gridUS1.GridviewUS.GetFocusedRow() as HangHoa;
            txtProductId.Text = current.ID.ToString();
            txtProductName.Text = current.Name.ToString();
            txtUnit.Text = current.DVT.ToString();
            nbNumber.Value = current.SoLuong;
            txtPriceBuy.Text = current.DonGiaNhap.ToString();
            txtPriceSale.Text = current.DonGiaBan.ToString();
            txtNote.Text = current.GhiChu == null ? "" : current.GhiChu;
        }
        private void Clear()
        {
            foreach (var obj in panelContent.Controls)
            {
                if (obj is TextBox)
                {
                    (obj as TextBox).Text = "";
                }
                else if (obj is NumericUpDown)
                {
                    (obj as NumericUpDown).Value = 0;
                }
            }
        }
    }
}
