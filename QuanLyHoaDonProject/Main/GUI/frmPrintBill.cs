using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Main.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils;
using System.Windows.Forms;
using DevExpress.Utils.Filtering.Internal;
using Main.GUI.Report;
using Main.DAO;
using System.Data.Entity;
using DevExpress.XtraReports.UI;

namespace Main.GUI
{
    public partial class frmPrintBill : Form
    {
        public frmPrintBill()
        {
            InitializeComponent();
            hdBUS = new HoaDonBUS();
            db = new QuanLyHoaDonContext();
        }
        private HoaDonBUS hdBUS;
        private QuanLyHoaDonContext db;
        private void frmPrintBill_Load(object sender, EventArgs e)
        {
            cmbHD.Properties.DataSource = null;
            cmbHD.Properties.View.Columns.Clear();
            loadComboboxHoaDon();
        }

        private void loadComboboxHoaDon()
        {
            var temp = hdBUS.getHoaDonBan();
            if (hdBUS.ErrorHDBUS != null)
            {
                MessageBox.Show("Lổi khi load danh sách hóa đơn", "Error");
                return;
            }
            
            GridColumn[] mField = new GridColumn[]
          {
                 new GridColumn() {Caption="Mã hóa đơn",FieldName="ID",Visible=true },
                  new GridColumn() {Caption="Ký hiệu",FieldName="KyHieu",Visible=true },
                   new GridColumn() {Caption="Ngày hóa đơn",FieldName="NgayHD",Visible=true },
                    new GridColumn() {Caption="Mã người mua",FieldName="NguoiMuaId",Visible=true },
          };
            cmbHD.Properties.View.Columns.AddRange(mField);
            GridColumn a = new GridColumn();
            a.Caption = "Tổng tiền";
            a.FieldName = "TongTienSo";
            a.DisplayFormat.FormatType = FormatType.Numeric;
            a.DisplayFormat.FormatString = "{0:0,0.0 đ}";
            a.Visible = true;
            cmbHD.Properties.View.Columns.Add(a);
            cmbHD.Properties.DataSource = temp;
            cmbHD.Properties.DisplayMember = "ID";
            cmbHD.Properties.ValueMember = "ID";
        }

        private void btnPri_Click(object sender, EventArgs e)
        {
            showpreviewHoaDon();
        }

        private void showpreviewHoaDon()
        {

//             var temp = (from cthd in db.CTHoaDons
//                        join hd in db.HoaDonBans on cthd.HoaDonBanId equals hd.ID
//                        join httt in db.HinhThucThanhToans on hd.HinhThucThanhToanId equals httt.ID
//                        join nm in db.NguoiMuas on hd.NguoiMuaId equals nm.ID
//                        join nvb in db.NhanVienBans on hd.NhanVienBanId equals nvb.ID
//                        join hh in db.HangHoas on cthd.HangHoaId equals hh.ID
//                        where cthd.HoaDonBanId == 31
//                        select new { cthd, hd, httt, nm, nvb, hh }).ToList();
            //                        select new
            //                        {
            //                            IdHD = hd.ID,
            //                            Thue = hd.ThueSuat,
            //                            KH = hd.KyHieu,
            //                            NgayHD = hd.NgayHD,
            //                            Nvb = nvb.Name,
            //                            Nm = nm.Name,
            //                            TongTienS = hd.TongTienSo,
            //                            TongTienC = hd.TongTienChu,
            //                            NHTT = httt.Name,
            //                            MSP = cthd.HangHoaId,
            //                            TSP = hh.Name,
            //                            SLM = cthd.SoLuongBan,
            //                            DG = hh.DonGiaBan,
            //                            DVT = hh.DVT
            //                        }).ToList();
            rp2 rp = new rp2();
            var temp = db.CTHoaDons.Where(x=>x.HoaDonBanId==32).ToList();
            rp.DataSource = temp;
            rp.ShowPreviewDialog();
            //documentViewer1.DocumentSource = rp;

        }
    }
}
