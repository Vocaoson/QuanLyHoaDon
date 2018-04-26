namespace Main.GUI.FormG
{
    partial class F1
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
            this.gridUS1 = new Main.GUI.GridUS.GridUS();
            this.SuspendLayout();
            // 
            // gridUS1
            // 
            this.gridUS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUS1.Location = new System.Drawing.Point(0, 0);
            this.gridUS1.Name = "gridUS1";
            this.gridUS1.Size = new System.Drawing.Size(464, 347);
            this.gridUS1.Source = null;
            this.gridUS1.TabIndex = 0;
            // 
            // F1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 347);
            this.Controls.Add(this.gridUS1);
            this.Name = "F1";
            this.Text = "F1";
            this.Load += new System.EventHandler(this.F1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GridUS.GridUS gridUS1;
    }
}