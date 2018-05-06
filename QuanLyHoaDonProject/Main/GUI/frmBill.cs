using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Main.BUS;
using Main.DTO;
using Money_Viet_Nam;
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
        private Mode cheDo = Mode.None;
        private int idNmHide = -1;

        private void frmBill_Load(object sender, EventArgs e)
        {
            addOneRow();
            var temp = hdBUS.getHoaDonBan();
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                
                deleteInfo();
                
            }
            loadDataDSHoaDon(temp);
            gridHD.GridviewUS.RowClick += GridviewUS_RowClick;
            gridHD.RefeshClick += GridHD_RefeshClick;
            gridHD.FindClick += GridHD_FindClick;
        }

        private void GridHD_FindClick(object sender, EventArgs e)
        {

            string noidungtimkiem = gridHD.ThongTinTimKiem;
            var temp = hdBUS.getHoaDonByFind(noidungtimkiem);
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                deleteInfo();
           
            }
            loadDataDSHoaDon(temp);
        }

        private void GridHD_RefeshClick(object sender, EventArgs e)
        {
            gridHD.ThongTinTimKiem = "";

        }

        private void GridviewUS_RowClick(object sender, RowClickEventArgs e)
        {
            if (CheDo == Mode.Seen || CheDo == Mode.None)
            {
                deleteInfo();
                CheDo = Mode.Seen;
                tControl.IsRowClick = true;
                if (gridHD.GridviewUS.SelectedRowsCount > 0)
                {
                    int iDHD = gridHD.GridviewUS.GetRowCellValue(e.RowHandle, "ID").toInt();
                    showData(iDHD);

                }

            }
        }
        public enum Mode
        {
            Seen,
            Edit,
            Delete,
            None
        }

        private void showData(int iDHD)
        {
            HoaDonBan temp = hdBUS.findHoaDon(iDHD);
            if (temp == null)
            {
                MessageBox.Show("Lổi khi lấy dữ liệu hóa đơn", "Error");
                return;
            }
            showHoaDon(temp);
            showNguoiMua(temp);
            showCTHoaDon(temp);
            addPanelTotal();
        }

        private void showCTHoaDon(HoaDonBan temp)
        {
            listHHSelect.Clear();
            List<CTHoaDon> lcthh = cthdBUS.getDsHH(temp.ID);
            gridTotalHH.DataSource = listHHSelect;
            if (lcthh == null)
            {
                MessageBox.Show("Lổi khi lấy dữ liệu chi tiết hóa đơn", "Error");
                return;
            }
            List<HangHoa> lhh = new List<HangHoa>();
            for (int i = 0; i < lcthh.Count; i++)
            {
                HangHoa temp2 = hhBUS.getHangHoaByID(lcthh[i].HangHoaId);
                if (temp2 == null)
                {
                    MessageBox.Show("Lổi khi lấy dữ liệu hàng hóa", "Error");
                    return;
                }
                lhh.Add(temp2);
            }
            for (int i = 0; i < lcthh.Count; i++)
            {
                listHHSelect.Add(new GioHang()
                {
                    STT = i + 1,
                    ID = lcthh[i].HangHoaId,
                    Name = lhh.Where(x => x.ID == lcthh[i].HangHoaId).SingleOrDefault().Name
                    ,
                    DVT = lhh.Where(x => x.ID == lcthh[i].HangHoaId).SingleOrDefault().DVT
                    ,
                    SoLuong = lcthh[i].SoLuongBan,
                    DonGia = lhh.Where(x => x.ID == lcthh[i].HangHoaId).SingleOrDefault().DonGiaBan
                    ,
                    ThanhTien = lcthh[i].ThanhTien,
                });
            }
            gridviewTTHH.RefreshData();



        }

        private void showNguoiMua(HoaDonBan temp)
        {

            NguoiMua kh = nmBUS.getNguoiMua(temp.NguoiMuaId);
            if (kh == null)
            {
                MessageBox.Show("Lổi khi lấy dữ liệu người mua", "Error");
                return;
            }
            idNmHide = kh.ID;
            txtNM.EditValue = kh.Name;
            txtCMND.EditValue = kh.CMND;
            List<DonViMuaHang> listDVMH = dvmhBUS.getAllDonViMuaHang();
            if (listDVMH.Count == 0)
            {
                MessageBox.Show("Bổ sung Đơn vị mua hàng", "Error");
                deleteInfo();
                return;
            }
            loadComboBoxDVMH(listDVMH);
            cmbDV.EditValue = kh.DonViMuaHangId;

        }

        private void showHoaDon(HoaDonBan temp)
        {

            txtIDHD.EditValue = temp.ID;
            txtNB.EditValue = temp.NgayHD;
            txtKH.EditValue = temp.KyHieu;
            numThue.Value = temp.ThueSuat.toDecimal();
            List<HinhThucThanhToan> listHTT = htttBUS.getAllListHTTT();
            if (listHTT.Count == 0)
            {
                MessageBox.Show("Bổ sung hình thức thanh toán", "Error");
                deleteInfo();
               
            }
            loadComboBoxHTTT(listHTT);
            cmbHTTT.EditValue = temp.HinhThucThanhToanId;
            List<NhanVienBan> listNVB = nvbBUS.getAllNhanVienBan();
            if (listNVB.Count == 0)
            {
                MessageBox.Show("Bổ sung Nhân viên bán hàng", "Error");
                deleteInfo();

            }
            loadComboBoxNVB(listNVB);
            cmbNVBH.EditValue = temp.NhanVienBanId;

        }

        private void loadDataDSHoaDon(List<object> source)
        {

            if (source==null)
            {
                return;
            }
            if (source.Count > 0)
            {
                gridHD.Source = source;
                gridHD.MapColumn("ID", "Mã HD", true, HorzAlignment.Far);
                gridHD.MapColumn("KyHieu", "Ký Hiệu", true, HorzAlignment.Far);
                gridHD.MapColumn("NgayHD", "Ngày Bán", true, HorzAlignment.Far);
                gridHD.MapColumn("TongTienSo", "Tổng Tiền", true, HorzAlignment.Far, FormatType.Numeric, "C0");


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
            tControl.EditEvent += TControl_EditEvent;
            tControl.DeleteEvent += TControl_DeleteEvent;

        }

        private void TControl_DeleteEvent(object sender, EventArgs e)
        {
            if (gridHD.GridviewUS.SelectedRowsCount > 0)
            {

                var temp = gridHD.GetValueCell("ID");
                if (deleteCTHoaDon(temp))
                {
                    if (deleteHoaDon(temp))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Delete");
                        var tempsource = hdBUS.getHoaDonBan();
                        if (hdBUS.ErrorHDBUS != null)
                        {
                            MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                            deleteInfo();
                            return;
                        }
                        loadDataDSHoaDon(tempsource);
                   
                        return;
                    }
                }
            }

        }

        private bool deleteHoaDon(List<object> id)
        {
            bool kq = hdBUS.deleteListHoaDonBUS(id);
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi xóa hóa đơn", "Error");
                return false;
            }
            return true;
        }

        private bool deleteCTHoaDon(List<object> id)
        {
            bool kq = cthdBUS.deleteListCtHoaDon(id);
            if (cthdBUS.ErrorCTHDBUS != null)
            {
                MessageBox.Show("Lổi khi xóa chi tiết hóa đơn", "Error");
                return false;
            }
            return true;
        }

        private void TControl_EditEvent(object sender, EventArgs e)
        {
            if (CheDo != Mode.Edit)
            {
                CheDo = Mode.Edit;
                if (gridHD.GridviewUS.SelectedRowsCount > 0)
                {
                    panelChiTietHoaDon();
                }
            }
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
                            hdBUS.deleteHoaDon(idhoadon);
                        }
                    }

                }
                deleteInfo();
            }
            else
            {
                tControl.isSuccessFul = false;
            }
        }

        private bool saveCtHoaDon(int idhoadon)
        {
            ///delete ct hoa don cu
            bool kq = cthdBUS.deleteCtHoaDon(idhoadon);
            if (kq == true)
            {
                var temp = listHHSelect.GroupBy(x => new { x.ID })
                                       .Select(g => new { ID = g.Key.ID, SoLuong = g.Sum(x => x.SoLuong.toLong()), ThanhTien = g.Sum(x => x.ThanhTien.toLong()) }).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    CTHoaDon ct = new CTHoaDon()
                    {
                        HoaDonBanId = idhoadon,
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
            return false;
        }

        private bool saveHoadon(ref int idhoadon, int idnguoimua)
        {
            bool isInsert = true;
            HoaDonBan hdTemp = hdBUS.findHoaDon(txtIDHD.EditValue.toInt());

            if (hdTemp != null)
            {
                isInsert = false;
            }
            else
            {
                hdTemp = new HoaDonBan();
            }
            hdTemp.ThueSuat = numThue.Value.toDouble();
            hdTemp.HinhThucThanhToanId = cmbHTTT.EditValue.toInt();
            hdTemp.KyHieu = txtKH.EditValue.ToString();
            hdTemp.NguoiMuaId = idnguoimua;
            hdTemp.NgayHD = txtNB.EditValue.toDateTime();
            hdTemp.DaXoa = false;
            hdTemp.NhanVienBanId = cmbNVBH.EditValue.toInt();
            hdTemp.TongTienSo = txtTotal.EditValue.ToString();
            hdTemp.TongTienChu = txtChuMoney.Text;

            if (isInsert)
            {
                hdBUS.insertHoaDonBan(hdTemp);

            }
            else
            {
                hdBUS.updateHoaDon();
            }
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi trong quá trình cập nhật hóa đơn", "Error");
                return false;
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn thành công", "Cập nhật hóa đơn");
                var temp = hdBUS.getHoaDonBan();
                if (hdBUS.ErrorHDBUS != null)
                {
                    MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                    deleteInfo();
                }
                loadDataDSHoaDon(temp);
                idhoadon = hdTemp.ID;
                return true;
            }


        }

        private bool saveKhachHang(ref int id)
        {
            bool isInsert = true;
            NguoiMua nmtemp = nmBUS.getNguoiMua(idNmHide);

            if (nmtemp != null)
            {
                isInsert = false;
            }
            else
            {
                nmtemp = new NguoiMua();
            }
            nmtemp.Name = txtNM.EditValue.ToString();
            nmtemp.CMND = txtCMND.EditValue.ToString();
            nmtemp.DonViMuaHangId = int.Parse(cmbDV.EditValue.ToString());

            if (isInsert)
            {
                bool tontaiCMND = nmBUS.checkCMND(nmtemp.CMND);
                if (nmBUS.ErrorNMBUS != null)
                {
                    MessageBox.Show(nmBUS.ErrorNMBUS.Message, "Error");
                    return false;
                }
                if (!tontaiCMND)
                {
                    nmBUS.insertNguoiMua(nmtemp);

                }
                else
                {
                    nmtemp.ID = nmBUS.getIdByCMND(nmtemp.CMND).toInt();
                }
            }
            else
            {
                nmBUS.updateNguoiMua();
            }
            if (nmBUS.ErrorNMBUS != null)
            {
                MessageBox.Show("Lổi trong quá trình cập nhật người mua", "Error");
                return false;
            }

            id = nmtemp.ID;
            return true;



        }


        private void checkData(ref bool kt)
        {
            ///panel HoaDon
            if (txtKH.EditValue == null)
            {
                tt.Show("Kí hiệu hóa đơn không hợp lệ", txtKH, 1500);
                kt = false;
                return;
            }
            if (cmbHTTT.EditValue == null)
            {

                tt.Show("Hình thức thanh toán không hợp lệ", cmbHTTT, 1500);
                kt = false;
                return;
            }
            if (cmbNVBH.EditValue == null)
            {

                tt.Show("Nhân viên bán hàng không hợp lệ", cmbNVBH, 1500);
                kt = false;
                return;
            }

            if (cmbDV.EditValue == null)
            {
                tt.Show("Đơn vị mua hàng không hợp lệ", cmbDV, 1500);
                kt = false;
                return;
            }
            if (txtNM.EditValue == null)
            {

                tt.Show("Tên khách mua hàng không hợp lệ", txtNM, 1500);
                kt = false;
                return;
            }
            if (txtCMND.Text == "" || txtCMND.Text.Length < 9)
            {

                tt.Show("CMND không hợp lệ", txtCMND, 1500);
                kt = false;
                return;
            }
            ///panel total
            if (listHHSelect.Count == 0)
            {
                tt.Show("Vui lòng chọn hàng hóa", btnADDHH, 1500);
                kt = false;
                return;
            }


        }

        private void TControl_CalcelEvent(object sender, EventArgs e)
        {
            gridHD.HideColumnSelect();
            deleteInfo();
            tControl.IsRowClick = false;
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
            CheDo = Mode.None;
            txtIDHD.EditValue = null;
            txtKH.EditValue = null;
            numThue.Value = 0;
            txtNB.Text = DateTime.Now.ToString("MM/dd/yyyy");
            clearComboBox(cmbHTTT);
            clearComboBox(cmbNVBH);
            ///Clear KH
            clearComboBox(cmbDV);
            txtNM.EditValue = null;
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
            txtChuMoney.Text = null;
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
            if (CheDo == Mode.Seen)
            {
                deleteInfo();
            }
            if (CheDo != Mode.Edit)
            {
                CheDo = Mode.Edit;
                tControl.IsRowClick = false;
                pnTT.Enabled = true;
                addNewHoaDonBan();

            }
        }

        private void addNewHoaDonBan()
        {
            int idhd = hdBUS.getIDHDB();
            if (idhd > 0)
            {
                CheDo = Mode.Edit;
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
            Class1 chu = new Class1();
            decimal tienhang = listHHSelect.Sum(x => x.ThanhTien.toLong());
            decimal thue = (numThue.Value * tienhang) / 100;
            txtTienHang.EditValue = tienhang;
            txtThue.EditValue = thue;
            txtTotal.EditValue = tienhang + thue;
            txtChuMoney.Text = chu.Chuyen(txtTotal.EditValue.toDouble());

        }

        List<GioHang> listHHSelect = new List<GioHang>();

        public Mode CheDo
        {
            get
            {
                return cheDo;
            }

            set
            {
                cheDo = value;
                switch (value)
                {
                    case Mode.Seen:

                        pnTT.Enabled = true;
                        txtKH.ReadOnly = true;
                        txtNB.ReadOnly = true;
                        numThue.Enabled = false;
                        cmbNVBH.ReadOnly = true;
                        cmbHTTT.ReadOnly = true;

                        cmbDV.ReadOnly = true;
                        txtNM.ReadOnly = true;
                        txtCMND.ReadOnly = true;
                        txtIDTHUE.ReadOnly = true;
                        txtSDT.ReadOnly = true;
                        txtSTK.ReadOnly = true;

                        txtTienHang.ReadOnly = true;
                        txtThue.ReadOnly = true;
                        txtTotal.ReadOnly = true;

                        btnADDHH.Enabled = false;
                        btnClearHH.Enabled = false;
                        btnXoa.Buttons[0].Enabled = false;
                        break;
                    case Mode.Edit:
                        pnTT.Enabled = true;
                        txtKH.ReadOnly = false;
                        txtNB.ReadOnly = false;
                        numThue.Enabled = true;
                        cmbNVBH.ReadOnly = false;
                        cmbHTTT.ReadOnly = false;

                        cmbDV.ReadOnly = false;
                        txtNM.ReadOnly = false;
                        txtCMND.ReadOnly = false;
                        txtIDTHUE.ReadOnly = false;
                        txtSDT.ReadOnly = false;
                        txtSTK.ReadOnly = false;

                        txtTienHang.ReadOnly = false;
                        txtThue.ReadOnly = false;
                        txtTotal.ReadOnly = false;

                        btnADDHH.Enabled = true;
                        btnClearHH.Enabled = true;
                        btnXoa.Buttons[0].Enabled = true;
                        break;
                }
            }
        }

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
            if (btnXoa.Buttons[0].Enabled)
            {
                object id = gridviewTTHH.GetRowCellValue(gridviewTTHH.FocusedRowHandle, "ID");
                int sl = int.Parse(gridviewTTHH.GetRowCellValue(gridviewTTHH.FocusedRowHandle, "SoLuong").ToString());
                HangHoa temphh = cmbHH.GetDataSourceRowByKeyValue(id) as HangHoa;
                temphh.SoLuong += sl;
                removeGioHang();
                addPanelTotal();
            }
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

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (CheDo == Mode.None || CheDo == Mode.Seen)
            {
                CheDo = Mode.Delete;
                if (gridHD.IsSelected)
                {
                    gridHD.HideColumnSelect();
                    CheDo = Mode.None;

                }
                else
                {
                    CheDo = Mode.Delete;
                    tControl.showDelete();
                    gridHD.ShowColumnSelect();
                }
            }
        }
    }
}
