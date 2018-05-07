using Main.BUS;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.GUI
{
    public partial class frmEmployee : Form
    {
        private bool isAdd;
        private bool isFind;
        NhanVienBanBUS nhanVienBanBus = new NhanVienBanBUS();
        private string BasePath
        {
            get
            {
                return Application.StartupPath;
            }
        }
        public frmEmployee()
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
        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            if (!inputIsCorrect()) return;
            taskControl1.isSuccessFul = true;
            var nhanVien = new NhanVienBan()
            {
                Name = txtEmployeeName.Text,
                DOB = dtBirthDay.Value,
                NgayCap = dtDate.Value,
                CMND = txtCMND.Text,
                NoiCap = txtPlaceMade.Text,
                GioiTinh = (string)cbSex.SelectedItem,
                HonNhan = cbMarried.SelectedItem != null? cbMarried.SelectedItem.ToString() == "Có" ? true : false :false,
                HinhAnh = picAvatar.Tag != null ? (string)picAvatar.Tag : "",
                SDT = txtPhoneNumber.Text,
                TTLamViec = (string)cbState.SelectedItem != null ? (string)cbState.SelectedItem : "",
                DiaChi = txtAddress.Text,
                DaXoa = false
            };
            if (isAdd)
            {
                var rs = nhanVienBanBus.Add(nhanVien);
                if (rs == true)
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
                else
                {
                    MessageBox.Show("Thêm nhân viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                nhanVien.ID = int.Parse(txtEmloyeeId.Text);
                var rs = nhanVienBanBus.Update(nhanVien);
                if (rs == false)
                {
                    MessageBox.Show("Sửa nhân viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAll();

                }
            }
            panelContent.Enabled = false;
        }

        private bool inputIsCorrect()
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return false;
            }
            if (cbSex.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSex.Focus();
                return false;
            }
            if (cbState.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tình trạng làm việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbState.Focus();
                return false;
            }
            if(txtPhoneNumber.Text != "")
            {
                if (!txtPhoneNumber.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhoneNumber.Focus();
                    return false;
                }
            }
            return true;
        }

        private void GridUS1_FindClick(object sender, EventArgs e)
        {
            isFind = true;
            LoadAll();
        }

        private void LoadAll()
        {
            var rs = new List<NhanVienBan>();
            if (isFind)
            {
                rs = nhanVienBanBus.FindByName(gridUS1.ThongTinTimKiem);
            }
            else
            {
                rs = nhanVienBanBus.GetAll();
            }
          
            if(rs != null && rs.Count > 0)
            {
                gridUS1.Source = rs;
                gridUS1.MapColumn("ID", "ID");
                gridUS1.MapColumn("Name", "Tên nhân viên");
                gridUS1.MapColumn("DOB", "Ngày sinh");
                gridUS1.MapColumn("CMND", "Chứng minh nhân dân");
                gridUS1.MapColumn("GioiTinh", "Giới tính");
                gridUS1.MapColumn("TTLamViec", "Tình trạng làm việc");
                gridUS1.VisibleColumn("HonNhan", false);
                gridUS1.VisibleColumn("DiaChi", false);
                gridUS1.VisibleColumn("DaXoa", false);
                gridUS1.VisibleColumn("NgayCap", false);
                gridUS1.VisibleColumn("NoiCap", false);
                gridUS1.VisibleColumn("HinhAnh", false);
                gridUS1.VisibleColumn("HoaDonBans", false);
            }
        }

        private void GridUS1_RefeshClick(object sender, EventArgs e)
        {
            isFind = false;
            LoadAll();
        }
        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            isAdd = true;
            Clear();
            panelContent.Enabled = true;
            txtEmployeeName.Focus();
        }
        private void GridviewUS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            taskControl1.IsRowClick = true;
            panelContent.Enabled = false;
            Bind();
        }

        private void Bind()
        {
            var nhanVien = gridUS1.GridviewUS.GetFocusedRow() as NhanVienBan;
            txtEmloyeeId.Text = nhanVien.ID.ToString();
            txtEmployeeName.Text = nhanVien.Name;
            txtCMND.Text = nhanVien.CMND;
            txtAddress.Text = nhanVien.DiaChi;
            cbMarried.SelectedItem = nhanVien.HonNhan == true ? "Có" : "Không";
            cbSex.SelectedItem = nhanVien.GioiTinh;
            cbState.SelectedItem = nhanVien.TTLamViec;
            dtBirthDay.Value = nhanVien.DOB;
            dtDate.Value = (DateTime)nhanVien.NgayCap;
            txtPlaceMade.Text = nhanVien.NoiCap;
            txtPhoneNumber.Text = nhanVien.SDT;
            if(File.Exists(string.Concat(BasePath, nhanVien.HinhAnh)))
            {
                picAvatar.Image = Image.FromFile(string.Concat(BasePath, nhanVien.HinhAnh));
            }
            else
            {
                picAvatar.Image = null;
            }
           
        }

        private void Clear()
        {
            foreach(var item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
                else if(item is ComboBox)
                {
                    (item as ComboBox).SelectedIndex = -1;
                }
                else if(item is DateTimePicker)
                {
                    (item as DateTimePicker).Value = DateTime.Now;
                }
            }
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;

        }
        private void TaskControl1_EditEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = true;
            txtEmployeeName.Focus();
            isAdd = false;
        }
        private void TaskControl1_DeleteEvent(object sender, EventArgs e)
        {
            NhanVienBan nv = new NhanVienBan() { ID = int.Parse(txtEmloyeeId.Text) };
            var rs = nhanVienBanBus.Delete(nv);
            if(rs == true)
            {
                MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadAll();
            var context = new ContextMenuStrip();
            var item2 = new ToolStripMenuItem("Cập nhật ảnh");
            item2.Click += Item2_Click;
            context.Items.Add(item2);
            picAvatar.ContextMenuStrip = context;
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            var rs = openFileDialog1.ShowDialog();
            if(rs == DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);
                var fileNameBeforeDot = file.Name.Substring(0,file.Name.LastIndexOf('.'));
                var afterDot = file.Name.Substring(file.Name.LastIndexOf('.'));
                string fileName = string.Concat(fileNameBeforeDot,DateTime.Now.Ticks, afterDot);
                var fileFullName = string.Concat(@"\..\..\Resources\", fileName);
                picAvatar.Tag = fileFullName;
                var fullPath = string.Concat(Application.StartupPath, fileFullName);
                File.Copy(openFileDialog1.FileName, fullPath);
                if (File.Exists(fullPath))
                {
                    picAvatar.Image = Image.FromFile(fullPath);
                }
                
            }        
        }
    }
}
