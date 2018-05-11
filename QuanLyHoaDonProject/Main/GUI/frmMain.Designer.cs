namespace Main
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnProduct = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBill = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnStatistic = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrintBill = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnInforCompany = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnProgramInfor = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOut = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonListPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonInforPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonOutPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMenu
            // 
            this.ribbonMenu.ExpandCollapseItem.Id = 0;
            this.ribbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMenu.ExpandCollapseItem,
            this.barBtnCustomer,
            this.barBtnProduct,
            this.barBtnBill,
            this.barBtnStatistic,
            this.barBtnPrintBill,
            this.barBtnInforCompany,
            this.barBtnProgramInfor,
            this.barBtnOut,
            this.barStaticItem2,
            this.btnEmployee});
            this.ribbonMenu.Location = new System.Drawing.Point(0, 0);
            this.ribbonMenu.MaxItemId = 14;
            this.ribbonMenu.Name = "ribbonMenu";
            this.ribbonMenu.OptionsMenuMinWidth = 300;
            this.ribbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonMenu.Size = new System.Drawing.Size(1054, 146);
            this.ribbonMenu.StatusBar = this.ribbonStatusBar1;
            this.ribbonMenu.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
            // 
            // barBtnCustomer
            // 
            this.barBtnCustomer.Caption = "Nhập khách hàng";
            this.barBtnCustomer.Id = 1;
            this.barBtnCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnCustomer.ImageOptions.Image")));
            this.barBtnCustomer.ImageOptions.ImageIndex = 0;
            this.barBtnCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnCustomer.ImageOptions.LargeImage")));
            this.barBtnCustomer.ImageOptions.LargeImageIndex = 0;
            this.barBtnCustomer.Name = "barBtnCustomer";
            this.barBtnCustomer.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCustomer_ItemClick);
            // 
            // barBtnProduct
            // 
            this.barBtnProduct.Caption = "Nhập hàng hóa";
            this.barBtnProduct.Id = 2;
            this.barBtnProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnProduct.ImageOptions.Image")));
            this.barBtnProduct.ImageOptions.ImageIndex = 1;
            this.barBtnProduct.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnProduct.ImageOptions.LargeImage")));
            this.barBtnProduct.ImageOptions.LargeImageIndex = 1;
            this.barBtnProduct.Name = "barBtnProduct";
            this.barBtnProduct.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnProduct_ItemClick);
            // 
            // barBtnBill
            // 
            this.barBtnBill.Caption = "Nhập hóa đơn";
            this.barBtnBill.Id = 3;
            this.barBtnBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnBill.ImageOptions.Image")));
            this.barBtnBill.ImageOptions.ImageIndex = 2;
            this.barBtnBill.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnBill.ImageOptions.LargeImage")));
            this.barBtnBill.ImageOptions.LargeImageIndex = 2;
            this.barBtnBill.Name = "barBtnBill";
            this.barBtnBill.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnBill_ItemClick);
            // 
            // barBtnStatistic
            // 
            this.barBtnStatistic.Caption = "Thống kê hóa đơn";
            this.barBtnStatistic.Id = 4;
            this.barBtnStatistic.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnStatistic.ImageOptions.Image")));
            this.barBtnStatistic.ImageOptions.ImageIndex = 3;
            this.barBtnStatistic.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnStatistic.ImageOptions.LargeImage")));
            this.barBtnStatistic.ImageOptions.LargeImageIndex = 3;
            this.barBtnStatistic.Name = "barBtnStatistic";
            this.barBtnStatistic.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnStatistic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnStatistic_ItemClick);
            // 
            // barBtnPrintBill
            // 
            this.barBtnPrintBill.Caption = "In hóa đơn";
            this.barBtnPrintBill.Id = 5;
            this.barBtnPrintBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnPrintBill.ImageOptions.Image")));
            this.barBtnPrintBill.ImageOptions.ImageIndex = 4;
            this.barBtnPrintBill.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnPrintBill.ImageOptions.LargeImage")));
            this.barBtnPrintBill.ImageOptions.LargeImageIndex = 4;
            this.barBtnPrintBill.Name = "barBtnPrintBill";
            this.barBtnPrintBill.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnPrintBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPrintBill_ItemClick);
            // 
            // barBtnInforCompany
            // 
            this.barBtnInforCompany.Caption = "Thông tin công ty";
            this.barBtnInforCompany.Id = 6;
            this.barBtnInforCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnInforCompany.ImageOptions.Image")));
            this.barBtnInforCompany.ImageOptions.ImageIndex = 5;
            this.barBtnInforCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnInforCompany.ImageOptions.LargeImage")));
            this.barBtnInforCompany.ImageOptions.LargeImageIndex = 5;
            this.barBtnInforCompany.Name = "barBtnInforCompany";
            this.barBtnInforCompany.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnInforCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnInforCompany_ItemClick);
            // 
            // barBtnProgramInfor
            // 
            this.barBtnProgramInfor.Caption = "Thông tin chương trình";
            this.barBtnProgramInfor.Id = 7;
            this.barBtnProgramInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnProgramInfor.ImageOptions.Image")));
            this.barBtnProgramInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnProgramInfor.ImageOptions.LargeImage")));
            this.barBtnProgramInfor.Name = "barBtnProgramInfor";
            this.barBtnProgramInfor.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnProgramInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnProgramInfor_ItemClick);
            // 
            // barBtnOut
            // 
            this.barBtnOut.Caption = "Thoát";
            this.barBtnOut.Id = 8;
            this.barBtnOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnOut.ImageOptions.Image")));
            this.barBtnOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnOut.ImageOptions.LargeImage")));
            this.barBtnOut.Name = "barBtnOut";
            this.barBtnOut.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOut_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 12;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Nhân viên";
            this.btnEmployee.Id = 13;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonListPage,
            this.ribbonInforPage,
            this.ribbonOutPage});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonListPage
            // 
            this.ribbonListPage.ItemLinks.Add(this.barBtnCustomer);
            this.ribbonListPage.ItemLinks.Add(this.btnEmployee);
            this.ribbonListPage.ItemLinks.Add(this.barBtnProduct);
            this.ribbonListPage.ItemLinks.Add(this.barBtnBill);
            this.ribbonListPage.ItemLinks.Add(this.barBtnStatistic);
            this.ribbonListPage.ItemLinks.Add(this.barBtnPrintBill);
            this.ribbonListPage.Name = "ribbonListPage";
            this.ribbonListPage.Text = "Danh mục";
            // 
            // ribbonInforPage
            // 
            this.ribbonInforPage.ItemLinks.Add(this.barBtnInforCompany);
            this.ribbonInforPage.ItemLinks.Add(this.barBtnProgramInfor);
            this.ribbonInforPage.Name = "ribbonInforPage";
            this.ribbonInforPage.Text = "Thông tin";
            // 
            // ribbonOutPage
            // 
            this.ribbonOutPage.ItemLinks.Add(this.barBtnOut);
            this.ribbonOutPage.Name = "ribbonOutPage";
            this.ribbonOutPage.Text = "Thoát chương trình";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 659);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonMenu;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1054, 27);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mdiManager
            // 
            this.mdiManager.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1054, 686);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình in hóa đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonListPage;
        private DevExpress.XtraBars.BarButtonItem barBtnCustomer;
        private DevExpress.XtraBars.BarButtonItem barBtnProduct;
        private DevExpress.XtraBars.BarButtonItem barBtnBill;
        private DevExpress.XtraBars.BarButtonItem barBtnStatistic;
        private DevExpress.XtraBars.BarButtonItem barBtnPrintBill;
        private DevExpress.XtraBars.BarButtonItem barBtnInforCompany;
        private DevExpress.XtraBars.BarButtonItem barBtnProgramInfor;
        private DevExpress.XtraBars.BarButtonItem barBtnOut;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonInforPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonOutPage;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiManager;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
    }
}

