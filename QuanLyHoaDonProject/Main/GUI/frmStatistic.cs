using DevExpress.XtraEditors.Controls;
using Main.BUS;
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
    public partial class frmStatistic : Form
    {
        HoaDonBUS hoaDonBus = new HoaDonBUS();
        DonViMuaHangBUS donViMuaHang = new DonViMuaHangBUS();
        bool isDate = true;
        public frmStatistic()
        {
            InitializeComponent();
            gridUS1.isStatistic = true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            isDate = true;
            var listHoaDon = hoaDonBus.GetByDate(dtFrom.Value, dtTo.Value);
            LoadSource(listHoaDon);
        }
        public void LoadSource(List<object> source)
        {
            if(source.Count == 0)
            {
                gridUS1.Source = null;
                return;
            }

            var listHoaDon = source;
            gridUS1.Source = listHoaDon;
            gridUS1.MapColumn("ID", "Số hóa đơn");
            gridUS1.MapColumn("KiHieu", "KH Hóa đơn");
            gridUS1.MapColumn("MaKhachHang", "Mã đơn vị mua");
            gridUS1.MapColumn("TenDonViMua", "Tên đơn vị mua");
            gridUS1.MapColumn("MaSoThue", "Mã số thuế");
            gridUS1.MapColumn("DiaChi", "Địa chỉ");
            gridUS1.MapColumn("STK", "Số tài khoản");
            gridUS1.MapColumn("NgayXuat", "Ngày xuất");
            gridUS1.MapColumn("HinhThuc", "HTTT");
            gridUS1.MapColumn("ThanhTien", "Thành tiền");
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            LoadAllDonViMuaHang();
        }
        private void LoadAllDonViMuaHang()
        {
            searchLookUpEdit1.Properties.DataSource = donViMuaHang.GetAll();
            searchLookUpEdit1.Properties.DisplayMember = "Name";
            searchLookUpEdit1.Properties.ValueMember = "ID";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("ID").Caption = "Mã đơn vị";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("Name").Caption = "Tên đơn vị";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("MaSoThueMua").Caption = "Mã số thuế";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("DiaChiMua").Caption = "Địa chỉ";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("STKMua").Caption = "Số tài khoản";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("SDTMua").Caption = "Số điện thoại";
        }

        private void btnSearchByCustomer_Click(object sender, EventArgs e)
        {
            isDate = false;
            var id = int.Parse(searchLookUpEdit1.EditValue.ToString());
            var list = hoaDonBus.GetHoaDonByDonViMua(id);
            LoadSource(list);
        }
    }
}
