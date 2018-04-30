using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
            hdBUS = new HoaDonBUS();
            htttBUS = new HinhThucThanhToanBUS();
            dvmhBUS = new DonViMuaHangBUS();
            nvbBUS = new NhanVienBanBUS();
            hhBUS = new HangHoaBUS();
        }
        HangHoaBUS hhBUS;
        DonViMuaHangBUS dvmhBUS;
        NhanVienBanBUS nvbBUS;
        HoaDonBUS hdBUS;
        HinhThucThanhToanBUS htttBUS;

        private void frmBill_Load(object sender, EventArgs e)
        {
            addOneRow();
            loadDataDSHoaDon();
        }

        private void loadDataDSHoaDon()
        {
            List<HoaDonBan> listHoadDon = hdBUS.getHoaDonBan();
            if (listHoadDon == null)
            {
                MessageBox.Show(hdBUS.ErrorHDBUS.Message, "Error");
            }
            else
            {
                if (listHoadDon.Count > 0)
                {
                    gridHD.Source = listHoadDon;
                }
            }
        }

        private void addOneRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("DVT", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(double));
            gridHH.DataSource = dt;
            gridviewHH.AddNewRow();
        }

        private void taskControl1_Load(object sender, EventArgs e)
        {
            tControl.AddEvent += TControl_AddEvent;
            tControl.CalcelEvent += TControl_CalcelEvent;
        }

        private void TControl_CalcelEvent(object sender, EventArgs e)
        {
            pnTT.Enabled = false;
            deleteInfo();
        }

        private void deleteInfo()
        {
            return;
        }

        private void TControl_AddEvent(object sender, EventArgs e)
        {
            pnTT.Enabled = true;
            addNewHoaDonBan();

        }

        private void addNewHoaDonBan()
        {
            int idhd = hdBUS.getIDHDB() + 1;
            if (idhd > 0)
            {
                ///Panel Hóa đơn
                txtIDHD.Text = idhd.ToString();
                txtNB.Text = DateTime.Now.ToString("dd/MM/yyyy");
                List<HinhThucThanhToan> listHTT = htttBUS.getAllListHTTT();
                if (listHTT.Count == 0)
                {
                    MessageBox.Show("Bổ sung hình thức thanh toán", "Error");

                    deleteInfo();
                    return;
                }
                loadComboBoxHTTT(listHTT);
                ///Panel khach hang
                List<DonViMuaHang> listDVMH = dvmhBUS.getAllDonViMuaHang();
                if (listDVMH.Count == 0)
                {
                    MessageBox.Show("Bổ sung Đơn vị mua hàng", "Error");
                    deleteInfo();
                    return;
                }
                loadComboBoxDVMH(listDVMH);
                List<NhanVienBan> listNVB = nvbBUS.getAllNhanVienBan();
                if (listNVB.Count == 0)
                {
                    MessageBox.Show("Bổ sung Nhân viên bán hàng", "Error");
                    deleteInfo();
                    return;
                }
                loadComboBoxNVB(listNVB);
                ///Panel chi tiet hang hoa
                List<HangHoa> listHH = hhBUS.getAllHangHoa();
                if (listHH.Count == 0)
                {
                    MessageBox.Show("Bổ sung Hàng hóa công ty", "Error");
                    deleteInfo();
                    return;
                }
                gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong", 0);
                loadComboBoxHH(listHH);


            }
            else
            {
                if (hdBUS.ErrorHDBUS != null)
                {
                    MessageBox.Show(hdBUS.ErrorHDBUS.Message);
                }
                deleteInfo();
            }
        }

        private void loadComboBoxHH(List<HangHoa> listHH)
        {

            cmbHH.Columns.AddRange(
               new LookUpColumnInfo[] {
                    new LookUpColumnInfo("ID","Mã"),
                     new LookUpColumnInfo("Name","Tên"),
                     new LookUpColumnInfo("DVT","Đơn vị tính"),
                     new LookUpColumnInfo("SoLuong","Số lượng"),
                     new LookUpColumnInfo("DonGiaNhap","Giá nhập"),
                     new LookUpColumnInfo("DonGiaBan","Giá bán"),
                      new LookUpColumnInfo("GhiChu","Ghi chú"),

               }
               );
            cmbHH.DataSource = listHH;
            cmbHH.DisplayMember = "ID";
            cmbHH.ValueMember = "ID";
        }

        private void loadComboBoxNVB(List<NhanVienBan> listNVB)
        {
            cmbNVBH.Properties.Columns.AddRange(
               new LookUpColumnInfo[] {
                     new LookUpColumnInfo("Name","Tên"),

               }
               );
            cmbNVBH.Properties.DataSource = listNVB;
            cmbNVBH.Properties.DisplayMember = "Name";
            cmbNVBH.Properties.ValueMember = "ID";
        }

        private void loadComboBoxDVMH(List<DonViMuaHang> listDVMH)
        {
            cmbDV.Properties.Columns.AddRange(
               new LookUpColumnInfo[] {
                     new LookUpColumnInfo("Name","Đơn vị"),

               }
               );
            cmbDV.Properties.DataSource = listDVMH;
            cmbDV.Properties.DisplayMember = "Name";
            cmbDV.Properties.ValueMember = "ID";
        }

        private void loadComboBoxHTTT(List<HinhThucThanhToan> listHTT)
        {
            cmbHTTT.Properties.Columns.AddRange(
                new LookUpColumnInfo[] {
                     new LookUpColumnInfo("Name","Hình Thức"),

                }
                );
            cmbHTTT.Properties.DataSource = listHTT;
            cmbHTTT.Properties.DisplayMember = "Name";
            cmbHTTT.Properties.ValueMember = "ID";
        }

        private void cmbDV_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbDV.EditValue != null)
            {
                DonViMuaHang temp = cmbDV.Properties.GetDataSourceRowByKeyValue(cmbDV.EditValue) as DonViMuaHang;
                txtIDTHUE.Text = temp.MaSoThueMua.ToString();
                txtSDT.Text = temp.SDTMua.ToString();
                txtSTK.Text = temp.STKMua.ToString();
                txtADD.Text = temp.DiaChiMua.ToString();
            }
        }

        private void cmbHH_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit cmb = sender as LookUpEdit;
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong", 0);
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "ThanhTien", 0);
            if (cmb.EditValue != null)
            {
                HangHoa hh = cmb.Properties.GetDataSourceRowByKeyValue(cmb.EditValue) as HangHoa;

                gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "Name", hh.Name);
                gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "DVT", hh.DVT);
                gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "DonGia", hh.DonGiaBan);
            }
        }
        private decimal getThanhTien()
        {
            decimal sl = Convert.ToDecimal(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong"));
            decimal dg = Convert.ToDecimal(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "DonGia"));
            return dg * sl;
        }


        private void txtSL_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit txt = sender as TextEdit;
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong", txt.EditValue);
            decimal temp = getThanhTien();
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "ThanhTien", temp);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool kt = checkChiTietHangHoa();
            if (kt == true)
            {
                addGridTTHH();
            }
        }

        private void addGridTTHH()
        {
            gridviewTTHH.SetRowCellValue(gridviewTTHH.FocusedRowHandle, "STT", gridviewTTHH.RowCount + 1);
            setGridTTHH("ID");
            setGridTTHH("Name");
            setGridTTHH("DonGia");
            setGridTTHH("SoLuong");
            setGridTTHH("ThanhTien");
            setGridTTHH("DVT");

        }
        private void setGridTTHH(string fieldName)
        {
            gridviewTTHH.SetRowCellValue(gridviewTTHH.FocusedRowHandle, fieldName, gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, fieldName));
        }

        private bool checkChiTietHangHoa()
        {
            string temp = gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "ID").ToString();
            if (temp == "")
            {
                MessageBox.Show("Vui lòng chọn hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            int temp2 = int.Parse(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong").ToString());
            if (temp2 <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}
