using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
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
            nmBUS = new NguoiMuaBUS();
            cthdBUS = new CTHoaDonBUS();
        }
        CTHoaDonBUS cthdBUS;
        NguoiMuaBUS nmBUS;
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
            var temp = hdBUS.getHoaDonBan();
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                deleteInfo();
            }
            else
            {
                if (temp.Count > 0)
                {
                    gridHD.Source = temp;
                    gridHD.MapColumn("ID", "Mã HD", true, HorzAlignment.Far);
                    gridHD.MapColumn("KyHieu", "Ký Hiệu", true, HorzAlignment.Far);
                    gridHD.MapColumn("NgayHD", "Ngày Bán", true, HorzAlignment.Far);
                    gridHD.MapColumn("TongTienSo", "Tổng Tiền", true, HorzAlignment.Far, FormatType.Numeric, "C0");


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
            gridviewHH.RefreshData();
        }

        private void taskControl1_Load(object sender, EventArgs e)
        {
            tControl.AddEvent += TControl_AddEvent;
            tControl.CalcelEvent += TControl_CalcelEvent;
            tControl.SaveEvent += TControl_SaveEvent;

        }
        /// <summary>
        /// Lưu hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TControl_SaveEvent(object sender, EventArgs e)
        {
            saveBill();
        }

        private void saveBill()
        {
            bool kt = true;
            checkData(ref kt);
            if (kt)
            {
                int idnguoimua = 0, idhoadon = 0;
                if (saveKhachHang(ref idnguoimua))
                {
                    if (saveHoadon(ref idhoadon, idnguoimua))
                    {
                       
                        if (saveCtHoaDon(idhoadon))
                        {
                            if (updateHangHoaKho())
                            {
                                tControl.isSuccessFul = true;
                            }


                        }
                        else
                        {
                            hdBUS.removeHoaDon(idhoadon);
                        }
                    }

                }
                deleteInfo();
            }
        }

        private bool saveHoadon(ref int idhd, int hdnm)
        {
            ///add hoa don
            HoaDonBan hdb = new HoaDonBan()
            {
                ThueSuat = numThue.Value.toDouble(),
                KyHieu = txtKH.EditValue.ToString(),
                HinhThucThanhToanId = cmbHTTT.EditValue.toInt(),
                NguoiMuaId = hdnm,
                NgayHD = txtNB.EditValue.toDateTime(),
                DaXoa = false,
                NhanVienBanId = cmbNVBH.EditValue.toInt(),
                TongTienSo = txtTotal.EditValue.ToString(),
                TongTienChu = txtTotal.EditValue.ToString(),
            };
            hdBUS.insertHoaDonBan(hdb);
            idhd = hdb.ID;
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi thêm hóa đơn", "Error");
                return false;
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thành công", "Thêm hoad đơn");

                loadDataDSHoaDon();
                return true;
            }
        }

        private bool saveCtHoaDon(int idhd)
        {
            ///addCThoaDon
           var temp= listHHSelect.GroupBy(x => new { x.ID })
                                       .Select(g => new { ID = g.Key.ID, SoLuong = g.Sum(x => x.SoLuong.toLong()), ThanhTien = g.Sum(x => x.ThanhTien.toLong()) }).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                CTHoaDon ct = new CTHoaDon()
                {
                    HoaDonBanId = idhd,
                    HangHoaId = temp[i].ID.toInt(),
                    ThanhTien = temp[i].ThanhTien.toDouble(),
                    SoLuongBan = temp[i].SoLuong.toInt(),
                };
                cthdBUS.insertCTHD(ct);
                if (cthdBUS.ErrorCTHDBUS != null)
                {
                    MessageBox.Show("Lổi khi thêm chi tiết hóa đơn", "Error");
                    return false;
                }
            }
            return true;
        }

        private bool saveKhachHang(ref int id)
        {
            ///kiem tra cmnd
            string cmnd = txtCMND.EditValue.ToString();
            bool tontaiCMND = nmBUS.checkCMND(cmnd);
            if (nmBUS.ErrorNMBUS != null)
            {
                MessageBox.Show(nmBUS.ErrorNMBUS.Message, "Error");
                return false;
            }

            if (tontaiCMND == false)
            {
                ///add nguoi mua
                NguoiMua objectNM = new NguoiMua()
                {
                    Name = cmbKH.Text,
                    CMND = cmnd,
                    DonViMuaHangId = int.Parse(cmbDV.EditValue.ToString()),
                };
                nmBUS.insertNguoiMua(objectNM);
                if (nmBUS.ErrorNMBUS != null)
                {
                    MessageBox.Show("Lổi khi thêm khách hàng mới", "Error");
                    return false;
                }
                id = objectNM.ID;
            }
            else
            {
                id = nmBUS.getIdByCMND(cmnd).toInt();
            }

            return true;



        }

        private void checkData(ref bool kt)
        {
            ///panel HoaDon
            if (txtKH.EditValue == null)
            {
                tt.Show("Kí hiệu hóa đơn không hợp lệ", txtKH);
                kt = false;
                return;
            }
            if (cmbHTTT.EditValue == null)
            {

                tt.Show("Hình thức thanh toán không hợp lệ", cmbHTTT);
                kt = false;
                return;
            }
            if (cmbNVBH.EditValue == null)
            {

                tt.Show("Nhân viên bán hàng không hợp lệ", cmbNVBH);
                kt = false;
                return;
            }

            if (cmbDV.EditValue == null)
            {
                tt.Show("Đơn vị mua hàng không hợp lệ", cmbDV);
                kt = false;
                return;
            }
            if (cmbKH.Text == "")
            {

                tt.Show("Tên khách mua hàng không hợp lệ", cmbKH);
                kt = false;
                return;
            }
            if (txtCMND.Text == "" || txtCMND.Text.Length < 9)
            {

                tt.Show("CMND không hợp lệ", txtCMND);
                kt = false;
                return;
            }
            ///panel total
            if (txtTotal.Text == "")
            {
                tt.Show("Vui lòng chọn hàng hóa", btnADDHH);
                kt = false;
                return;
            }


        }

        private void TControl_CalcelEvent(object sender, EventArgs e)
        {
            deleteInfo();
            pnTT.Enabled = false;

        }
        private void clearComboBox(LookUpEdit cmb)
        {
            cmb.Properties.DataSource = null;
            cmb.Properties.Columns.Clear();
            cmb.Properties.ValueMember = null;
        }
        private void deleteInfo()
        {
            ///Clear panel HD
            txtIDHD.EditValue = null;
            txtKH.EditValue = null;
            numThue.Value = 0;
            txtNB.Text = DateTime.Now.ToString("MM/dd/yyyy");
            clearComboBox(cmbHTTT);
            clearComboBox(cmbNVBH);
            ///Clear KH
            clearComboBox(cmbDV);
            cmbKH.DataSource = null;
            txtCMND.EditValue = null;
            txtIDTHUE.EditValue = null;
            txtSDT.EditValue = null;
            txtSTK.EditValue = null;
            txtADD.EditValue = null;

            //clear CThh
            cmbHH.DataSource = null;
            cmbHH.Columns.Clear();
            clearCTHangHoa();
            ///clearGioHang
            listHHSelect.Clear();
            gridviewTTHH.RefreshData();
            txtTienHang.EditValue = null;
            txtThue.EditValue = null;
            txtTotal.EditValue = null;
            pnTT.Enabled = false;
            return;
        }

        private void clearCTHangHoa()
        {
    
           
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "ID", "");
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "Name", "");
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "DVT", "");
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong", "");
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "DonGia", "");
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "ThanhTien", "");

        }

        private void TControl_AddEvent(object sender, EventArgs e)
        {
            if (pnTT.Enabled==false)
            {
                pnTT.Enabled = true;
                addNewHoaDonBan();
            }

        }

        private void addNewHoaDonBan()
        {
            int idhd = hdBUS.getIDHDB();
            if (idhd > 0)
            {
                addOneRow();
                ///Panel Hóa đơn
                panelHoadon(idhd);
                ///Panel khach hang
                panelKhachHang();
                ///Panel chi tiet hang hoa
                panelChiTietHoaDon();

            }
            else
            {
                if (hdBUS.ErrorHDBUS != null)
                {
                    MessageBox.Show("Lổi hệ thống", "Error");
                }
                deleteInfo();
            }

        }

        private bool updateHangHoaKho()
        {
            for (int i = 0; i < listHHSelect.Count; i++)
            {
                HangHoa temp = hhBUS.checkHangHoaKho(listHHSelect[i].ID);
                if (temp == null)
                {
                    MessageBox.Show("Lổi cập nhật hàng hóa", "Error");
                    return false;
                }
                hhBUS.updateHangHoa(temp);
            }
            return true;
        }

        private void panelChiTietHoaDon()
        {
            List<HangHoa> listHH = hhBUS.getAllHangHoa();
            if (listHH.Count == 0)
            {
                MessageBox.Show("Bổ sung Hàng hóa công ty", "Error");
                deleteInfo();
                return;
            }
            loadComboBoxHH(listHH);
            gridTotalHH.DataSource = listHHSelect;
        }

        private void panelKhachHang()
        {
            List<DonViMuaHang> listDVMH = dvmhBUS.getAllDonViMuaHang();
            if (listDVMH.Count == 0)
            {
                MessageBox.Show("Bổ sung Đơn vị mua hàng", "Error");
                deleteInfo();
                return;
            }
            loadComboBoxDVMH(listDVMH);
            cmbKH.DisplayMember = "Name";
            cmbKH.ValueMember = "CMND";
        }

        private void panelHoadon(int idhd)
        {
            txtIDHD.Text = idhd.ToString();
            txtNB.Text = DateTime.Now.ToString("MM/dd/yyyy");
            List<HinhThucThanhToan> listHTT = htttBUS.getAllListHTTT();
            if (listHTT.Count == 0)
            {
                MessageBox.Show("Bổ sung hình thức thanh toán", "Error");
                deleteInfo();
                return;
            }
            loadComboBoxHTTT(listHTT);
            List<NhanVienBan> listNVB = nvbBUS.getAllNhanVienBan();
            if (listNVB.Count == 0)
            {
                MessageBox.Show("Bổ sung Nhân viên bán hàng", "Error");
                deleteInfo();
                return;
            }
            loadComboBoxNVB(listNVB);
        }

        private void loadComboBoxHH(List<HangHoa> listHH)
        {

            cmbHH.DataSource = listHH.ToList();
            cmbHH.DisplayMember = "ID";
            cmbHH.ValueMember = "ID";
            cmbHH.Columns.AddRange(
                new LookUpColumnInfo[] {
                    new LookUpColumnInfo("ID","Mã"),
                     new LookUpColumnInfo("Name","Tên"),
                     new LookUpColumnInfo("DVT","Đơn vị tính"),
                     new LookUpColumnInfo("SoLuong","Số lượng"),
                     new LookUpColumnInfo("DonGiaNhap","Giá nhập"),
                     new LookUpColumnInfo("DonGiaBan","Giá bán"),
                      new LookUpColumnInfo("GhiChu","Ghi chú"),
                });
        }

        private void loadComboBoxNVB(List<NhanVienBan> listNVB)
        {
            LookUpColumnInfo[] mField = new LookUpColumnInfo[]
             {
               new LookUpColumnInfo("Name","Tên"),
             };
            loadComboBox(cmbNVBH, listNVB.Cast<object>().ToList(), "Name", "ID", mField);


        }

        private void loadComboBoxDVMH(List<DonViMuaHang> listDVMH)
        {
            LookUpColumnInfo[] mField = new LookUpColumnInfo[]
             {
               new LookUpColumnInfo("Name","Đơn vị"),
             };
            loadComboBox(cmbDV, listDVMH.Cast<object>().ToList(), "Name", "ID", mField);

        }

        private void loadComboBoxHTTT(List<HinhThucThanhToan> listHTT)
        {
            LookUpColumnInfo[] mField = new LookUpColumnInfo[]
            {
                 new LookUpColumnInfo("Name","Hình Thức"),
            };
            loadComboBox(cmbHTTT, listHTT.Cast<object>().ToList(), "Name", "ID", mField);


        }
        private void loadComboBox(LookUpEdit cmb, List<object> listSource, string display, string value, LookUpColumnInfo[] mFielCaption)
        {
            cmb.Properties.DataSource = listSource;
            cmb.Properties.DisplayMember = display;
            cmb.Properties.ValueMember = value;
            cmb.Properties.Columns.AddRange(mFielCaption);

        }

        private void cmbDV_EditValueChanged(object sender, EventArgs e)
        {
            cmbKH.Text = "";
            if (cmbDV.EditValue != null)
            {
                DonViMuaHang temp = cmbDV.Properties.GetDataSourceRowByKeyValue(cmbDV.EditValue) as DonViMuaHang;
                txtIDTHUE.Text = temp.MaSoThueMua.ToString();
                txtSDT.Text = temp.SDTMua.ToString();
                txtSTK.Text = temp.STKMua.ToString();
                txtADD.Text = temp.DiaChiMua.ToString();
                cmbKH.DataSource = temp.NguoiMuas.Where(x => x.DaXoa == false).ToList();
                cmbKH.SelectedIndex = -1;

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
            object temp = gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong");
            decimal sl;
            bool kt = false;
            kt = decimal.TryParse(temp.ToString(), out sl);
            if (!kt)
            {
                sl = 0;
                return -1;

            }
            decimal dg = Convert.ToDecimal(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "DonGia"));
            return dg * sl;
        }


        private void txtSL_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit txt = sender as TextEdit;
            if (txt.EditValue == null)
            {
                txt.EditValue = 0;
                return;
            }
            ///kiem tra so luong nhap
            HangHoa temphh = cmbHH.GetDataSourceRowByKeyValue(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "ID")) as HangHoa;
            int sl = int.Parse(txt.EditValue.ToString());
            if (sl > temphh.SoLuong)
            {
                MessageBox.Show("Số lượng nhập vượt quá số lượng trong kho!!", "Error");
                txt.EditValue = 0;
                return;
            }
            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "SoLuong", txt.EditValue);
            decimal temp = getThanhTien();
            if (temp == -1)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gridviewHH.SetRowCellValue(gridviewHH.FocusedRowHandle, "ThanhTien", temp);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool kt = checkChiTietHangHoa();
            if (kt == true)
            {
                addGridTTHH();
                addPanelTotal();
            }
        }

        private void addPanelTotal()
        {
            decimal tienhang = listHHSelect.Sum(x => x.ThanhTien.toLong());
            decimal thue = (numThue.Value * tienhang) / 100;
            txtTienHang.EditValue = tienhang;
            txtThue.EditValue = thue;
            txtTotal.EditValue = tienhang + thue;

        }

        List<GioHang> listHHSelect = new List<GioHang>();

        private void addGridTTHH()
        {

            HangHoa temp = cmbHH.GetDataSourceRowByKeyValue(gridviewHH.GetRowCellValue(gridviewHH.FocusedRowHandle, "ID")) as HangHoa;
            int sl = int.Parse(getValue(gridviewHH, "SoLuong").ToString());
            if (sl > temp.SoLuong)
            {
                MessageBox.Show("Số lượng nhập vượt quá giới hạn trong kho", "Error");
                return;
            }
            temp.SoLuong -= sl;
            listHHSelect.Add(new GioHang()
            {
                STT = listHHSelect.Count + 1,
                ID = getValue(gridviewHH, "ID"),
                Name = getValue(gridviewHH, "Name"),
                DVT = getValue(gridviewHH, "DVT"),
                SoLuong = getValue(gridviewHH, "SoLuong"),
                DonGia = getValue(gridviewHH, "DonGia"),
                ThanhTien = getValue(gridviewHH, "ThanhTien")
            });
            gridviewTTHH.RefreshData();


        }
        private object getValue(GridView gridview, string fieldName)
        {
            return gridview.GetRowCellValue(gridview.FocusedRowHandle, fieldName);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            object id = gridviewTTHH.GetRowCellValue(gridviewTTHH.FocusedRowHandle, "ID");
            int sl = int.Parse(gridviewTTHH.GetRowCellValue(gridviewTTHH.FocusedRowHandle, "SoLuong").ToString());
            HangHoa temphh = cmbHH.GetDataSourceRowByKeyValue(id) as HangHoa;
            temphh.SoLuong += sl;
            removeGioHang();
            addPanelTotal();
        }

        private void removeGioHang()
        {
            int indexrow = gridviewTTHH.FocusedRowHandle;
            listHHSelect.RemoveAt(indexrow);
            for (int i = 0; i < listHHSelect.Count; i++)
            {
                listHHSelect[i].STT = i + 1;
            }
            gridviewTTHH.RefreshData();
        }

        private void numThue_ValueChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text != "")
            {
                addPanelTotal();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clearCTHangHoa();
            
        }


    }
}
