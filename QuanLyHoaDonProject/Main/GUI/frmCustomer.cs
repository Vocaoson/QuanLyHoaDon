using DevExpress.XtraLayout;
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
    public partial class frmCustomer : Form
    {
        DonViMuaHangBUS donvimuahangBUS = new DonViMuaHangBUS();
        bool isEdit;
        public frmCustomer()
        {
            InitializeComponent();
            taskControl1.AddEvent += TaskControl1_AddEvent;
            taskControl1.EditEvent += TaskControl1_EditEvent;
            taskControl1.DeleteEvent += TaskControl1_DeleteEvent;
            taskControl1.SaveEvent += TaskControl1_SaveEvent;
            taskControl1.CalcelEvent += TaskControl1_CalcelEvent;
            gridUS1.GridviewUS.RowClick += GridviewUS_RowClick;
        }

        private void GridviewUS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            taskControl1.IsRowClick = true;
            AddBinding();
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;
            RefeshForm();
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            if (inputIsCorrect() == true)
            {
                taskControl1.isSuccessFul = true;
                var donvimuahang = new DonViMuaHang();
                SetDTO(donvimuahang);
                if (isEdit == false)
                {
                    var add = donvimuahangBUS.Add(donvimuahang);
                    if (add == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearBinding();
                }
                else
                {
                    donvimuahang.ID = int.Parse(txtCusID.Text);
                    var edit = donvimuahangBUS.Update(donvimuahang);
                    if (edit == true)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefeshForm();
                panelContent.Enabled = false;
            }
        }

        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            var value = gridUS1.GetValueCell("ID");
            string temp = "";
            if (value != null)
            {

                foreach (var item in value)
                {
                    temp += item;
                }
            }
            int id = int.Parse(temp);
            if (donvimuahangBUS.Delete(id) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else MessageBox.Show("Xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            isEdit = true;
            panelContent.Enabled = true;
            txtCusName.Focus();
        }

        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isEdit = false;
            panelContent.Enabled = true;
            ClearBinding();
            txtCusName.Focus();
        }
        /// <summary>
        ///  Binding grid với textbox
        /// </summary>
        private void AddBinding()
        {
            var dto = gridUS1.GridviewUS.GetFocusedRow() as DonViMuaHang;
            txtCusID.Text = dto.ID.ToString();
            txtCusName.Text = dto.Name;
            txtAddress.Text = dto.DiaChiMua;
            txtMST.Text = dto.MaSoThueMua;
            txtPhone.Text = dto.SDTMua;
            txtSTK.Text = dto.STKMua;
        }
        /// <summary>
        /// remove Binding
        /// </summary>
        private void ClearBinding()
        {
            txtCusID.Text = "";
            txtCusName.Text = "";
            txtMST.Text = "";
            txtPhone.Text = "";
            txtSTK.Text = "";
            txtAddress.Text = "";
        }
        /// <summary>
        /// Gán giá trị cho đối tượng
        /// </summary>
        private void SetDTO(DonViMuaHang dv)
        {
            dv.Name = txtCusName.Text;
            dv.DiaChiMua = txtAddress.Text;
            dv.MaSoThueMua = txtMST.Text;
            dv.STKMua = txtSTK.Text;
            dv.SDTMua = txtPhone.Text;
        }
        /// <summary>
        /// Load dữ liệu grid
        /// </summary>
        private void LoadData()
        {
            var list = donvimuahangBUS.GetAll();
            if (list == null)
            {
                MessageBox.Show("Xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            else
            {
                if (list.Count > 0)
                {
                    gridUS1.Source = list;
                    LoadColumn();
                    
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// Map tên cột, ẩn hiện các cột cần thiết
        /// </summary>
        private void LoadColumn()
        {
            gridUS1.MapColumn("ID", "Mã đơn vị");
            gridUS1.MapColumn("Name", "Tên đơn vị");
            gridUS1.MapColumn("MaSoThueMua", "Mã số thuế");
            gridUS1.MapColumn("DiaChiMua", "Địa chỉ");
            gridUS1.MapColumn("STKMua", "Số tài khoản");
            gridUS1.MapColumn("SDTMua", "Số điện thoại");
            gridUS1.VisibleColumn("NguoiMuas", false);
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// kiểm tra dữ liệu nhập
        /// </summary>
        /// <returns></returns>
        private bool inputIsCorrect()
        {
            taskControl1.isSuccessFul = false;
            if (string.IsNullOrEmpty(txtCusName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCusName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMST.Text))
            {
                MessageBox.Show("Vui lòng nhập mã số thuế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMST.Focus();
                return false;
            }
            if (!txtPhone.Text.All(char.IsDigit)|| string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!txtSTK.Text.All(char.IsDigit)||string.IsNullOrEmpty(txtSTK.Text))
            {
                MessageBox.Show("Số tài khoản chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSTK.Focus();
                return false;
            }
            return true;
        }
        private void gridUS1_Load(object sender, EventArgs e)
        {
            gridUS1.FindClick += GridUS1_FindClick;
            gridUS1.RefeshClick += GridUS1_RefeshClick;
        }

        private void GridUS1_RefeshClick(object sender, EventArgs e)
        {
            gridUS1.ThongTinTimKiem = "";
            RefeshForm();
            LoadData();
        }

        /// <summary>
        /// Làm tươi nơi nhập dữ liệu
        /// </summary>
        private void RefeshForm()
        {
            for (int i = 0; i < layoutControl1.Items.Count; i++)
            {

                if (layoutControl1.Items[i].GetType().ToString() == "DevExpress.XtraLayout.LayoutControlItem")
                {
                    (layoutControl1.Items[i] as LayoutControlItem).Control.Text = "";
                }
            }
        }
        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            var search = donvimuahangBUS.Search(gridUS1.ThongTinTimKiem);
            if (search != null)
            {
                if (search.Count > 0)
                {
                    gridUS1.Source = search;
                    LoadColumn();
                }
                else MessageBox.Show("Kết quả tìm kiếm không có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}