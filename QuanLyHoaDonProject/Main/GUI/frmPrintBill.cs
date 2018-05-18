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
using DevExpress.DocumentView;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.Pdf;

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
                MessageBox.Show("Lỗi khi load danh sách hóa đơn", "Error");
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
            if (cmbHD.EditValue != null)
            {
                showpreviewHoaDon(cmbHD.EditValue);
                btnPDF.Enabled = true;
            }
            else
            {
                tt.Show("Chọn hóa đơn", cmbHD, 1500);
                btnPDF.Enabled = false;
            }
        }
        reportHoaDon rpF;
        private void showpreviewHoaDon(object editValue)
        {
           
            int temp;
            bool kq = int.TryParse(editValue.ToString(), out temp);
            if (!kq)
            {
                btnPDF.Enabled = false;
                return;
            }
            var temp2 = db.CTHoaDons.Where(x => x.HoaDonBanId == temp).ToList();
            reportHoaDon rp = new reportHoaDon(temp2);
            documentViewer1.DocumentSource = rp;
            rp.Nap = false;
            rpF = rp;
            rp.CreateDocument(false);
        }
        private void documentViewer_MouseMove(object sender, MouseEventArgs e)
        {


            if (rpF != null && rpF.IsMove)
            {
                Point screenPoint = System.Windows.Forms.Cursor.Position;

                ViewManager viewManager = documentViewer1.ViewManager;
                PSPage page = viewManager.FindPage(screenPoint) as PSPage;
                if (page != null)
                {

                    PointF pageLocation = viewManager.GetPageRect(page).Location;
                    PointF pt = documentViewer1.ViewControl.PointToClient(screenPoint);
                    pt = PSUnitConverter.PixelToDoc(pt, documentViewer1.Zoom, viewManager.ScrollValue);
                    pt = new PointF(pt.X - pageLocation.X - page.MarginsF.Left, pt.Y - pageLocation.Y - page.MarginsF.Top);
                    rpF.SizePage = page.Size;
                    rpF.PointTemp = pt;
                }

            }

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (rpF == null)
            {
                btnPDF.Enabled = false;
                return;
            }
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                using (PdfDocumentProcessor process = new PdfDocumentProcessor())
                {
                    process.CreateEmptyDocument();
                    process.LoadDocument(openFileDialog1.FileName);
                    Bitmap bm = process.CreateBitmap(1, 2000);
                    rpF.Watermark.Image = bm;
                    rpF.Watermark.ImageViewMode = ImageViewMode.Stretch;
                    rpF.CreateDocument(false);
                }

            }
        }
    }
}
