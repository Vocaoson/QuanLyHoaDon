using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Main.GUI.GridUS
{
    public partial class GridUS : UserControl
    {
        public GridUS()
        {
            InitializeComponent();

        }


        public object Source
        {
            get
            {
                return gridControl1.DataSource;
            }

            set
            {
                if (value != null)
                {
                    gridControl1.DataSource = value;
                }
            }
        }

        public GridView GridviewUS
        {
            get
            {
                return gridView1;
            }

            set
            {
                gridView1 = value;
            }
        }

        public void MapColumn(string nameProperty, string caption)
        {
            gridView1.Columns[nameProperty].Caption = caption;
        }
        public void VisibleColumn(string nameProperty, bool option)
        {
            gridView1.Columns[nameProperty].Visible = option;
        }
        public void AddCoumn(string fieldName, string caption, RepositoryItem item)
        {
            gridView1.Columns.AddVisible(fieldName, caption);
            gridView1.Columns[fieldName].ColumnEdit = item;
            gridControl1.RepositoryItems.Add(item);
        }

    }
}
