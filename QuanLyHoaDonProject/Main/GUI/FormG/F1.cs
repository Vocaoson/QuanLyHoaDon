using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Main.DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace Main.GUI.FormG
{
    public partial class F1 : DevExpress.XtraEditors.XtraForm
    {
        QuanLyHoaDonContext db;
        public F1()
        {
            InitializeComponent();
            db = new QuanLyHoaDonContext();
        }

        private void F1_Load(object sender, EventArgs e)
        {
            gridUS1.Source = db.HinhThucThanhToans.ToList();
            gridUS1.MapColumn("ID", "Mã");
            gridUS1.MapColumn("Name", "Thanh Toán");
            //////////////////////////////////////////////////////////////////////////
            gridUS1.VisibleColumn("HoaDonBans", false);
            //////////////////////////////////////////////////////////////////////////
            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.ValueChecked = "True";
            edit.ValueUnchecked = "False";
            edit.EditValueChanged += Rcb_EditValueChanged;
            gridUS1.AddCoumn("Check", "CheckBox", edit);
        }

        private void Rcb_EditValueChanged(object sender, EventArgs e)
        {
            if (true)
            {
                gridUS1.GridviewUS.SetRowCellValue(0, "Check", "True");
            }
//             gridUS1.GridviewUS.PostEditor();
//             CheckEdit checkEdit = sender as CheckEdit;
//             int indexRow = gridUS1.GridviewUS.GetSelectedRows()[0];
//             gridUS1.GridviewUS.SetRowCellValue(indexRow, "Check", "True");
        }
    }
}