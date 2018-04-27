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
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace Main.GUI.GridUS
{
    public partial class GridUS : UserControl, INotifyPropertyChanged
    {
        public GridUS()
        {
            InitializeComponent();
         
            Binding data = new Binding("EditValue", this, "ThongTinTimKiem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTT.DataBindings.Add(data);
           
        }
        private bool isValid = false;
        private string thongTinTimKiem;
        private event EventHandler findClick;
        public event EventHandler FindClick
        {
            add
            {
                findClick += value;
            }
            remove
            {
                findClick -= value;
            }
        }
        private event EventHandler refeshClick;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }

        public event EventHandler RefeshClick
        {
            add
            {
                refeshClick += value;
            }
            remove
            {
                refeshClick -= value;
            }
        }
        int pageCurrent = 1;
        private int numberRecord = 10;
        List<object> temp;
        /// <summary>
        /// Lấy dữ liệu gán vào datasource grid
        /// </summary>
        public object Source
        {
            get
            {
                return gridControl1.DataSource;
            }

            set
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                if (value != null)
                {
                    isValid = true;
                    temp = ((IEnumerable)value).Cast<object>().ToList();
                    numUD.Maximum = ((double)temp.Count / numberRecord) == (int)((double)temp.Count / numberRecord)
                                    ? (temp.Count / numberRecord) : ((temp.Count / numberRecord) + 1);
                    numUD.Minimum = 1;
                    numUD.Value = 1;
                    gridControl1.DataSource = LoadPhanTrang(numberRecord,PageCurrent);
                   
                }
            }
        }
        /// <summary>
        /// Load dữ  liệu lên grid theo trang và số dòng quy định
        /// </summary>
        /// <param name="numberRecords">Số dòng thiển thị</param>
        /// <param name="pageCurrents">trang hiện tại</param>
        /// <returns></returns>
        private object LoadPhanTrang(int numberRecords,int pageCurrents)
        {
            if (isValid)
            {
                return temp.Skip((pageCurrents - 1) * numberRecords).Take(numberRecords).ToList();
            }
            return null;
          
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

        public int NumberRecord
        {
            get
            {
                return numberRecord;
            }

            set
            {
                numberRecord = value;
            }
        }

        public int PageCurrent
        {
            get
            {
                return pageCurrent;
            }

            set
            {
                
                if (value != pageCurrent)
                {
                    pageCurrent = value;
                    numUD.Value = value;
                    gridControl1.DataSource = LoadPhanTrang( numberRecord, pageCurrent);
                }
            }
        }
        /// <summary>
        /// Láy Thông tin nhập ô tìm kiếm
        /// </summary>
        public string ThongTinTimKiem
        {
            get
            {
                return thongTinTimKiem;
            }

            set
            {
                thongTinTimKiem = value;
                OnPropertyChanged("ThongTinTimKiem");
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
            }
        }

        /// <summary>
        /// Map name property vs caption hiển thị
        /// </summary>
        /// <param name="nameProperty">Name property</param>
        /// <param name="caption">Hiển thị</param>
        /// <param name="fixedWidth">fix widh colum</param>
        public void MapColumn(string nameProperty, string caption,bool fixedWidth=false)
        {
            if (fixedWidth==true)
            {
                gridView1.Columns[nameProperty].OptionsColumn.FixedWidth = true;
            }
            gridView1.Columns[nameProperty].Caption = caption;
        }
        /// <summary>
        /// Ẩn cột không cần thiết
        /// </summary>
        /// <param name="nameProperty">Thuộc tính của object</param>
        /// <param name="option">Lựa chọn ẩn/hiện</param>
        public void VisibleColumn(string nameProperty, bool option)
        {
            gridView1.Columns[nameProperty].Visible = option;
        }
        /// <summary>
        /// Thêm cột vào gridview
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="visible"></param>
        public void AddColumn(string fieldName,string caption,bool visible)
        {
            GridColumn myCol = new GridColumn() { Caption = caption, Visible = visible, FieldName = fieldName };
            gridView1.Columns.Add(myCol);
        }
        /// <summary>
        /// Thêm cột Repository vào gridview
        /// </summary>
        /// <param name="fieldName">Field cột</param>
        /// <param name="caption">Hiển thị</param>
        /// <param name="item"> Repository item muốn tạo</param>
        public void AddColumnRepository(string fieldName, RepositoryItem item)
        {
     
            gridView1.Columns[fieldName].ColumnEdit = item;
            gridControl1.RepositoryItems.Add(item);
        }
        /// <summary>
        /// First page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           if (isValid)
           {
                PageCurrent = 1;
            }
        }
        /// <summary>
        /// Previous Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (isValid&&pageCurrent-1>0)
            {
                PageCurrent--;
            }
            
        }
        /// <summary>
        /// Next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (isValid&&pageCurrent<numUD.Maximum)
            {
                PageCurrent++;
            }
           
        }
        /// <summary>
        /// Last page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (isValid)
            {
                PageCurrent = int.Parse(numUD.Maximum.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUD_ValueChanged(object sender, EventArgs e)
        {
           if (isValid)
           {
                PageCurrent = int.Parse(numUD.Value.ToString());
            }
        }
        /// <summary>
        /// Click Làm Mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            refeshClick?.Invoke(sender, e);
        }
        /// <summary>
        ///Click Tìm Kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            findClick?.Invoke(sender, e);
        }
        /// <summary>
        /// Xóa cột gridview
        /// </summary>
        /// <param name="fieldName"></param>
        public void DeleteColumn(string fieldName)
        {
            gridView1.Columns.Remove(gridView1.Columns[fieldName]);
        }
        /// <summary>
        /// Format kiểu hiển thị columns
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="typeFormat"></param>
        /// <param name="stringFormat"></param>
        public void FormatColumn(string fieldName,FormatType typeFormat,string stringFormat)
        {
            gridView1.Columns[fieldName].DisplayFormat.FormatType = typeFormat;
            gridView1.Columns[fieldName].DisplayFormat.FormatString = stringFormat;
        }
        /// <summary>
        /// Get value row click
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public List<object> GetValueCell(string fieldName)
        {
            List<object> temp=null;
            int soluongSelecet = gridView1.GetSelectedRows().Count();
            if (soluongSelecet>0)
            {
                temp = new List<object>();
                for (int i = 0; i < soluongSelecet; i++)
                {
                    object value= gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], fieldName);
                    temp.Add(value);
                }
            }
            return temp;
         
        }
        /// <summary>
        /// Get index row click
        /// </summary>
        /// <returns></returns>
        public int GetIndexRow()
        {
            return gridView1.GetSelectedRows()[0];
        }
        private bool isSelected = false;
        /// <summary>
        /// Show cột Select
        /// </summary>
        public void ShowColumnSelect()
        {
            isSelected = true;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }
        /// <summary>
        /// Ẩn cột Select
        /// </summary>
        public void HideColumnSelect()
        {
            isSelected = false;
            gridView1.OptionsSelection.MultiSelect = false;
        }
    }
}
