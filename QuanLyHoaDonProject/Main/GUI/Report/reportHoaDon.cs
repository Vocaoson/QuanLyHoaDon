using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Main.DTO;

namespace Main.GUI.Report
{
    public partial class reportHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public reportHoaDon(List<CTHoaDon>Source)
        {
            InitializeComponent();
            DataSource = Source;
            lsour = Source;
        }
        List<CTHoaDon> lsour;
        private bool isMove = false;

        public bool IsMove
        {
            get
            {
                return isMove;
            }

            set
            {
                isMove = value;
            }
        }

        public PointF PointTemp
        {
            set
            {
                if (sizePage != null)
                {
                    if (isMove)
                    {

                      
                        if (value.X < 0 || value.Y < 0 || value.X> sizePage.Width || value.Y > sizePage.Height)
                        {
                            return;
                        }
                        float x = value.X-5;
                        float y = value.Y-5;
                        temp.Brick.Location = new PointF(x, y);
                        temp.PreviewControl.Invalidate();
                        temp.PreviewControl.Refresh();
                    }
                }
            }
        }

        public SizeF SizePage
        {
            get
            {
                return sizePage;
            }

            set
            {
                sizePage = value;
            }
        }
        PreviewMouseEventArgs temp;
        private SizeF sizePage;
        object controls;

        private void xrLabel_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            if (isMove)
            {
                temp.Brick.BackColor = Color.Transparent;
                temp.PreviewControl.Refresh();
                controls = null;
                isMove = false;
                temp = null;
            }
            else
            {
                e.Brick.BackColor = Color.LightBlue;
                e.PreviewControl.Refresh();
                isMove = true;
                controls = sender;
                temp = e;
            }
        }


        private XRLabel createrLabel(string Text,float x, float y)
        {
            XRLabel lbl = new XRLabel();
            lbl.Text = Text;
            lbl.AutoWidth = true;
            lbl.CanGrow = false;
            lbl.WordWrap = false;
            lbl.LocationF = new PointF(x,y);
            lbl.PreviewClick += xrLabel_PreviewClick;
            return lbl;
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupHeaderBand temp = sender as GroupHeaderBand;
            if (lsour.Count > 0)
            {
                for (int i = 0; i < lsour.Count; i++)
                {
                    temp.Controls.Add(createrLabel(lsour[i].HangHoaId.ToString(), 0, temp.Controls[temp.Controls.Count - 1].Height + temp.Controls[temp.Controls.Count - 1].LocationF.Y));
                    temp.Controls.Add(createrLabel(lsour[i].HangHoa.Name, temp.Controls[temp.Controls.Count - 1] .Location.X+ 70, temp.Controls[temp.Controls.Count - 1].Top));
                    temp.Controls.Add(createrLabel(lsour[i].HangHoa.DVT, temp.Controls[temp.Controls.Count - 1].Location.X + 70, temp.Controls[temp.Controls.Count - 1].Top));
                    temp.Controls.Add(createrLabel(lsour[i].HangHoa.DonGiaBan.ToString(), temp.Controls[temp.Controls.Count - 1].Location.X + 70, temp.Controls[temp.Controls.Count - 1].Top));
                    temp.Controls.Add(createrLabel(lsour[i].SoLuongBan.ToString(), temp.Controls[temp.Controls.Count - 1].Location.X + 70, temp.Controls[temp.Controls.Count - 1].Top));
                    temp.Controls.Add(createrLabel(lsour[i].ThanhTien.ToString(), temp.Controls[temp.Controls.Count - 1].Location.X + 70, temp.Controls[temp.Controls.Count - 1].Top));
                    temp.Controls.Add(createrLabel(lsour[i].HangHoa.GhiChu, temp.Controls[temp.Controls.Count - 1].Location.X + 70, temp.Controls[temp.Controls.Count - 1].Top));

                }
            }
        }


    }
}
