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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            taskControl1.AddEvent += TaskControl1_AddEvent;
            taskControl1.SaveEvent += TaskControl1_SaveEvent;
            taskControl1.CalcelEvent += TaskControl1_CalcelEvent;
        }

        private void TaskControl1_CalcelEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;
        }

        private void TaskControl1_SaveEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = false;
        }

        //when user click Add a product
        private void TaskControl1_AddEvent(object sender, EventArgs e)
        {
            panelContent.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
