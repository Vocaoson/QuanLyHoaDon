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
    public partial class frmLogin : Form
    {
        DangNhapBUS dangnhapBUS = new DangNhapBUS();
        DangNhap dangnhap = new DangNhap();
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (inputIsCorrect() == true)
            {
                dangnhap.TenDangNhap = txtUserName.Text;
                dangnhap.PassWord = txtPassWord.Text;
                if (dangnhapBUS.TestAccount(dangnhap) == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain frm = new frmMain();
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    if (dangnhapBUS.Error == null) MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else MessageBox.Show("Xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return false;
            }
            return true;
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}