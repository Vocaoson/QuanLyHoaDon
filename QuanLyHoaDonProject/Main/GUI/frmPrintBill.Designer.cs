namespace Main.GUI
{
    partial class frmPrintBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBill));
            this.panel1 = new System.Windows.Forms.Panel();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnPri = new DevExpress.XtraEditors.SimpleButton();
            this.cmbHD = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbHD);
            this.panel1.Controls.Add(this.btnPri);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 51);
            this.panel1.TabIndex = 0;
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(0, 51);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.ShowPageMargins = false;
            this.documentViewer1.Size = new System.Drawing.Size(633, 309);
            this.documentViewer1.Status = "Vui lòng chọn hóa đơn";
            this.documentViewer1.TabIndex = 1;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 20);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Chọn hóa đơn:";
            // 
            // btnPri
            // 
            this.btnPri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPri.ImageOptions.Image")));
            this.btnPri.Location = new System.Drawing.Point(290, 12);
            this.btnPri.Name = "btnPri";
            this.btnPri.Size = new System.Drawing.Size(114, 29);
            this.btnPri.TabIndex = 2;
            this.btnPri.Text = "Xem trang in";
            this.btnPri.Click += new System.EventHandler(this.btnPri_Click);
            // 
            // cmbHD
            // 
            this.cmbHD.Location = new System.Drawing.Point(96, 16);
            this.cmbHD.Name = "cmbHD";
            this.cmbHD.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbHD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cmbHD.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbHD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHD.Properties.NullText = "";
            this.cmbHD.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbHD.Size = new System.Drawing.Size(188, 20);
            this.cmbHD.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmPrintBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 360);
            this.Controls.Add(this.documentViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintBill";
            this.Text = "In hóa đơn";
            this.Load += new System.EventHandler(this.frmPrintBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraEditors.SimpleButton btnPri;
        private System.Windows.Forms.Label lbl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbHD;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}