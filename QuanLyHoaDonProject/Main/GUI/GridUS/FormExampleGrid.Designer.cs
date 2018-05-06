namespace Main.GUI.GridUS
{
    partial class FormExampleGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExampleGrid));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridUS1 = new Main.GUI.GridUS.GridUS();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(337, 275);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(77, 31);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Select";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // gridUS1
            // 
            this.gridUS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUS1.IsSelected = false;
            this.gridUS1.Location = new System.Drawing.Point(0, 0);
            this.gridUS1.Name = "gridUS1";
            this.gridUS1.NumberRecord = 10;
            this.gridUS1.PageCurrent = 1;
            this.gridUS1.Size = new System.Drawing.Size(414, 307);
            this.gridUS1.Source = null;
            this.gridUS1.TabIndex = 2;
            this.gridUS1.ThongTinTimKiem = null;
            this.gridUS1.Load += new System.EventHandler(this.gridUS1_Load);
            // 
            // FormExampleGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 307);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridUS1);
            this.Name = "FormExampleGrid";
            this.Text = "FormExampleGrid";
            this.Load += new System.EventHandler(this.FormExampleGrid_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private GridUS gridUS1;
    }
}