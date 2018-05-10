using Main.BUS;
using Main.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.GUI
{
    public partial class frmStartProgram : Form
    {
        ProductBus bus = new ProductBus();
        ProgramBUS programBus = new ProgramBUS();
        event EventHandler success;
        public frmStartProgram()
        {
            InitializeComponent();
            success += FrmStartProgram_success;
        }

        private void FrmStartProgram_success(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                progressBar1.Value = progressBar1.Maximum;
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
                frm.FormClosed += Frm_FormClosed;
          
            }));
    
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var number = (float)progressBar1.Value / progressBar1.Maximum * 100;
            if(number >= 99)
            {
                timer1.Stop();
            }
            lbValue.Text = string.Concat(number, "%");
            progressBar1.PerformStep();
        }

        private void frmStartProgram_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                try
                {
                    var rs = bus.GetAll();
                    if(programBus.CountHTTT() == 0)
                    {
                        programBus.AddDefaultHTTT("Trực tiếp");
                        programBus.AddDefaultHTTT("Chuyển khoản");
                    }
                    if (rs != null)
                    {
                        success?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Có lỗi trong quá trình kết nối đến cơ sở dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }));
                    }
                }
                catch
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Có lỗi trong quá trình kết nối đến cơ sở dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }));

                }
             
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
