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
    public partial class frmCompanyInfor : Form
    {
        DonViBanHangBUS donvibanhangBUS = new DonViBanHangBUS();
        DonViBanHang dv=new DonViBanHang();
        public frmCompanyInfor()
        {
            InitializeComponent();
        }

        private void frmCompanyInfor_Load(object sender, EventArgs e)
        {
            dv = donvibanhangBUS.GetDVMH();
            if (dv == null)
            {
                if (donvibanhangBUS.Error != null)
                {
                    MessageBox.Show("Xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                }    
            }
            else
            {
                txtName.Text = dv.Name;
                txtMST.Text = dv.MaSoThueBan;
                txtAddress.Text = dv.DiaChi;
                txtSDT.Text = dv.SDTBan;
                txtSTK.Text = dv.STKBan;
                txtName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            var isNew = false;
            if(dv == null)
            {
                dv = new DonViBanHang();
                isNew = true;
            }
            dv.Name = txtName.Text;
            dv.MaSoThueBan = txtMST.Text;
            dv.DiaChi = txtAddress.Text;
            dv.SDTBan = txtSDT.Text;
            dv.STKBan = txtSTK.Text;
            var rs = false;
            if(isNew == true)
            {
                rs = donvibanhangBUS.Add(dv);
            }
            else
            {
                rs = donvibanhangBUS.Update(dv);
            }
            if (rs == true)
            {
                MessageBox.Show("Cập nhật đơn vị bán hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật đơn vị bán hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMST.Text))
            {
                MessageBox.Show("Vui lòng nhập mã số thuế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMST.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (!txtSDT.Text.All(char.IsDigit) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (!txtSTK.Text.All(char.IsDigit) || string.IsNullOrEmpty(txtSTK.Text))
            {
                MessageBox.Show("Số tài khoản chỉ có thể là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSTK.Focus();
                return false;
            }
            return true;
        }
    }
}