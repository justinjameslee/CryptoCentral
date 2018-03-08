namespace CryptoCentral
{
    partial class Crypto
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crypto));
            this.Header = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerRefreshing = new System.Windows.Forms.Timer(this.components);
            this.timerSyncTimer = new System.Windows.Forms.Timer(this.components);
            this.timerUpdating = new System.Windows.Forms.Timer(this.components);
            this.Footer = new System.Windows.Forms.Panel();
            this.gifRefreshing = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.lblSyncTimer = new System.Windows.Forms.Label();
            this.lblSync = new System.Windows.Forms.Label();
            this.btnPageRight = new System.Windows.Forms.PictureBox();
            this.btnPageLeft = new System.Windows.Forms.PictureBox();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.RoundedCornersMain = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SidebarTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.SummaryContainer = new System.Windows.Forms.Panel();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.OptionsContainer = new System.Windows.Forms.Panel();
            this.WorkerContainer = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Sidebar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.SidebarSeperator = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMining = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.FadeForm = new Bunifu.Framework.UI.BunifuFormFadeTransition(this.components);
            this.timerSummaryLoad = new System.Windows.Forms.Timer(this.components);
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Controls.Add(this.Logo);
            this.Header.Controls.Add(this.btnClose);
            this.Header.Controls.Add(this.btnMinimize);
            this.Header.Controls.Add(this.label3);
            this.SidebarTransition.SetDecoration(this.Header, BunifuAnimatorNS.DecorationType.None);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1940, 55);
            this.Header.TabIndex = 2;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.White;
            this.SidebarTransition.SetDecoration(this.Logo, BunifuAnimatorNS.DecorationType.None);
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(222, 55);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Logo_MouseDown);
            // 
            // btnClose
            // 
            this.SidebarTransition.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1015, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            // 
            // btnMinimize
            // 
            this.SidebarTransition.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(963, 16);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 24);
            this.btnMinimize.TabIndex = 49;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Walkway Bold", 18F);
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(242, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "ADMIN";
            // 
            // timerRefreshing
            // 
            this.timerRefreshing.Enabled = true;
            this.timerRefreshing.Interval = 50;
            this.timerRefreshing.Tick += new System.EventHandler(this.timerRefreshing_Tick);
            // 
            // timerSyncTimer
            // 
            this.timerSyncTimer.Enabled = true;
            this.timerSyncTimer.Interval = 1000;
            this.timerSyncTimer.Tick += new System.EventHandler(this.timerSyncTimer_Tick);
            // 
            // timerUpdating
            // 
            this.timerUpdating.Interval = 2000;
            this.timerUpdating.Tick += new System.EventHandler(this.timerUpdating_Tick);
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.Color.Moccasin;
            this.Footer.Controls.Add(this.gifRefreshing);
            this.Footer.Controls.Add(this.btnRefresh);
            this.Footer.Controls.Add(this.lblSyncTimer);
            this.Footer.Controls.Add(this.lblSync);
            this.Footer.Controls.Add(this.btnPageRight);
            this.Footer.Controls.Add(this.btnPageLeft);
            this.Footer.Controls.Add(this.lblCurrentPage);
            this.SidebarTransition.SetDecoration(this.Footer, BunifuAnimatorNS.DecorationType.None);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(222, 1033);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(1718, 38);
            this.Footer.TabIndex = 6;
            // 
            // gifRefreshing
            // 
            this.SidebarTransition.SetDecoration(this.gifRefreshing, BunifuAnimatorNS.DecorationType.None);
            this.gifRefreshing.Image = ((System.Drawing.Image)(resources.GetObject("gifRefreshing.Image")));
            this.gifRefreshing.Location = new System.Drawing.Point(870, 7);
            this.gifRefreshing.Name = "gifRefreshing";
            this.gifRefreshing.Size = new System.Drawing.Size(24, 24);
            this.gifRefreshing.TabIndex = 63;
            this.gifRefreshing.TabStop = false;
            this.gifRefreshing.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Moccasin;
            this.SidebarTransition.SetDecoration(this.btnRefresh, BunifuAnimatorNS.DecorationType.None);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(758, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 62;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSyncTimer
            // 
            this.lblSyncTimer.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.lblSyncTimer, BunifuAnimatorNS.DecorationType.None);
            this.lblSyncTimer.Font = new System.Drawing.Font("Walkway Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncTimer.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSyncTimer.Location = new System.Drawing.Point(789, 7);
            this.lblSyncTimer.Name = "lblSyncTimer";
            this.lblSyncTimer.Size = new System.Drawing.Size(49, 22);
            this.lblSyncTimer.TabIndex = 68;
            this.lblSyncTimer.Text = "(30)";
            this.lblSyncTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSync
            // 
            this.SidebarTransition.SetDecoration(this.lblSync, BunifuAnimatorNS.DecorationType.None);
            this.lblSync.Font = new System.Drawing.Font("Walkway Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSync.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSync.Location = new System.Drawing.Point(638, 9);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(112, 20);
            this.lblSync.TabIndex = 61;
            this.lblSync.Text = "SYNCED";
            this.lblSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPageRight
            // 
            this.SidebarTransition.SetDecoration(this.btnPageRight, BunifuAnimatorNS.DecorationType.None);
            this.btnPageRight.Image = ((System.Drawing.Image)(resources.GetObject("btnPageRight.Image")));
            this.btnPageRight.Location = new System.Drawing.Point(115, 7);
            this.btnPageRight.Name = "btnPageRight";
            this.btnPageRight.Size = new System.Drawing.Size(24, 24);
            this.btnPageRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPageRight.TabIndex = 60;
            this.btnPageRight.TabStop = false;
            this.btnPageRight.Click += new System.EventHandler(this.btnPageControlClick);
            this.btnPageRight.MouseEnter += new System.EventHandler(this.btnPageHoverEnter);
            this.btnPageRight.MouseLeave += new System.EventHandler(this.btnPageHoverLeave);
            // 
            // btnPageLeft
            // 
            this.btnPageLeft.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.btnPageLeft, BunifuAnimatorNS.DecorationType.None);
            this.btnPageLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnPageLeft.Image")));
            this.btnPageLeft.Location = new System.Drawing.Point(6, 7);
            this.btnPageLeft.Name = "btnPageLeft";
            this.btnPageLeft.Size = new System.Drawing.Size(24, 24);
            this.btnPageLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPageLeft.TabIndex = 58;
            this.btnPageLeft.TabStop = false;
            this.btnPageLeft.Click += new System.EventHandler(this.btnPageControlClick);
            this.btnPageLeft.MouseEnter += new System.EventHandler(this.btnPageHoverEnter);
            this.btnPageLeft.MouseLeave += new System.EventHandler(this.btnPageHoverLeave);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblCurrentPage, BunifuAnimatorNS.DecorationType.None);
            this.lblCurrentPage.Font = new System.Drawing.Font("Walkway Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPage.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentPage.Location = new System.Drawing.Point(36, 9);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(73, 20);
            this.lblCurrentPage.TabIndex = 59;
            this.lblCurrentPage.Text = "PAGE 1";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoundedCornersMain
            // 
            this.RoundedCornersMain.ElipseRadius = 15;
            this.RoundedCornersMain.TargetControl = this;
            // 
            // SidebarTransition
            // 
            this.SidebarTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.SidebarTransition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.SidebarTransition.DefaultAnimation = animation1;
            this.SidebarTransition.MaxAnimationTime = 1000;
            this.SidebarTransition.AllAnimationsCompleted += new System.EventHandler(this.SidebarTransition_AllAnimationsCompleted);
            // 
            // SummaryContainer
            // 
            this.SidebarTransition.SetDecoration(this.SummaryContainer, BunifuAnimatorNS.DecorationType.None);
            this.SummaryContainer.Location = new System.Drawing.Point(225, 77);
            this.SummaryContainer.Name = "SummaryContainer";
            this.SummaryContainer.Size = new System.Drawing.Size(183, 106);
            this.SummaryContainer.TabIndex = 53;
            // 
            // LoadingPanel
            // 
            this.SidebarTransition.SetDecoration(this.LoadingPanel, BunifuAnimatorNS.DecorationType.None);
            this.LoadingPanel.Location = new System.Drawing.Point(695, 77);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(194, 106);
            this.LoadingPanel.TabIndex = 54;
            // 
            // OptionsContainer
            // 
            this.SidebarTransition.SetDecoration(this.OptionsContainer, BunifuAnimatorNS.DecorationType.None);
            this.OptionsContainer.Location = new System.Drawing.Point(225, 189);
            this.OptionsContainer.Name = "OptionsContainer";
            this.OptionsContainer.Size = new System.Drawing.Size(183, 106);
            this.OptionsContainer.TabIndex = 57;
            // 
            // WorkerContainer
            // 
            this.SidebarTransition.SetDecoration(this.WorkerContainer, BunifuAnimatorNS.DecorationType.None);
            this.WorkerContainer.Location = new System.Drawing.Point(225, 301);
            this.WorkerContainer.Name = "WorkerContainer";
            this.WorkerContainer.Size = new System.Drawing.Size(183, 106);
            this.WorkerContainer.TabIndex = 58;
            // 
            // pictureBox3
            // 
            this.SidebarTransition.SetDecoration(this.pictureBox3, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(222, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(842, 16);
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // Sidebar
            // 
            this.Sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sidebar.BackgroundImage")));
            this.Sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sidebar.Controls.Add(this.SidebarSeperator);
            this.Sidebar.Controls.Add(this.btnBack);
            this.Sidebar.Controls.Add(this.btnSettings);
            this.Sidebar.Controls.Add(this.btnMining);
            this.Sidebar.Controls.Add(this.btnHome);
            this.SidebarTransition.SetDecoration(this.Sidebar, BunifuAnimatorNS.DecorationType.None);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.Location = new System.Drawing.Point(0, 55);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Quality = 10;
            this.Sidebar.Size = new System.Drawing.Size(222, 1016);
            this.Sidebar.TabIndex = 56;
            // 
            // SidebarSeperator
            // 
            this.SidebarSeperator.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.SidebarSeperator, BunifuAnimatorNS.DecorationType.None);
            this.SidebarSeperator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.SidebarSeperator.LineThickness = 1;
            this.SidebarSeperator.Location = new System.Drawing.Point(0, 93);
            this.SidebarSeperator.Name = "SidebarSeperator";
            this.SidebarSeperator.Size = new System.Drawing.Size(222, 35);
            this.SidebarSeperator.TabIndex = 61;
            this.SidebarSeperator.Transparency = 255;
            this.SidebarSeperator.Vertical = false;
            // 
            // btnBack
            // 
            this.btnBack.Activecolor = System.Drawing.Color.Orange;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 0;
            this.btnBack.ButtonText = " LOG OUT";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SidebarTransition.SetDecoration(this.btnBack, BunifuAnimatorNS.DecorationType.None);
            this.btnBack.DisabledColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBack.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBack.Iconimage = global::CryptoCentral.Properties.Resources.Exit_100px;
            this.btnBack.Iconimage_right = null;
            this.btnBack.Iconimage_right_Selected = null;
            this.btnBack.Iconimage_Selected = null;
            this.btnBack.IconMarginLeft = 27;
            this.btnBack.IconMarginRight = 0;
            this.btnBack.IconRightVisible = false;
            this.btnBack.IconRightZoom = 0D;
            this.btnBack.IconVisible = true;
            this.btnBack.IconZoom = 55D;
            this.btnBack.IsTab = true;
            this.btnBack.Location = new System.Drawing.Point(0, 485);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBack.OnHovercolor = System.Drawing.Color.Orange;
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(222, 38);
            this.btnBack.TabIndex = 60;
            this.btnBack.Text = " LOG OUT";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Textcolor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Activecolor = System.Drawing.Color.Orange;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.BorderRadius = 0;
            this.btnSettings.ButtonText = " OPTIONS";
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SidebarTransition.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnSettings.DisabledColor = System.Drawing.Color.Gray;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSettings.Iconimage = global::CryptoCentral.Properties.Resources.Settings_100px;
            this.btnSettings.Iconimage_right = null;
            this.btnSettings.Iconimage_right_Selected = null;
            this.btnSettings.Iconimage_Selected = null;
            this.btnSettings.IconMarginLeft = 27;
            this.btnSettings.IconMarginRight = 0;
            this.btnSettings.IconRightVisible = false;
            this.btnSettings.IconRightZoom = 0D;
            this.btnSettings.IconVisible = true;
            this.btnSettings.IconZoom = 55D;
            this.btnSettings.IsTab = true;
            this.btnSettings.Location = new System.Drawing.Point(0, 233);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSettings.OnHovercolor = System.Drawing.Color.Orange;
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSettings.selected = false;
            this.btnSettings.Size = new System.Drawing.Size(222, 36);
            this.btnSettings.TabIndex = 59;
            this.btnSettings.Text = " OPTIONS";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Textcolor = System.Drawing.Color.White;
            this.btnSettings.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMining
            // 
            this.btnMining.Activecolor = System.Drawing.Color.Orange;
            this.btnMining.BackColor = System.Drawing.Color.Transparent;
            this.btnMining.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMining.BorderRadius = 0;
            this.btnMining.ButtonText = " MINING";
            this.btnMining.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SidebarTransition.SetDecoration(this.btnMining, BunifuAnimatorNS.DecorationType.None);
            this.btnMining.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnMining.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMining.Iconimage = global::CryptoCentral.Properties.Resources.Golden_Fever_100px;
            this.btnMining.Iconimage_right = null;
            this.btnMining.Iconimage_right_Selected = null;
            this.btnMining.Iconimage_Selected = null;
            this.btnMining.IconMarginLeft = 27;
            this.btnMining.IconMarginRight = 0;
            this.btnMining.IconRightVisible = false;
            this.btnMining.IconRightZoom = 0D;
            this.btnMining.IconVisible = true;
            this.btnMining.IconZoom = 55D;
            this.btnMining.IsTab = true;
            this.btnMining.Location = new System.Drawing.Point(0, 185);
            this.btnMining.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMining.Name = "btnMining";
            this.btnMining.Normalcolor = System.Drawing.Color.Transparent;
            this.btnMining.OnHovercolor = System.Drawing.Color.Orange;
            this.btnMining.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMining.selected = false;
            this.btnMining.Size = new System.Drawing.Size(222, 36);
            this.btnMining.TabIndex = 58;
            this.btnMining.Text = " MINING";
            this.btnMining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMining.Textcolor = System.Drawing.Color.White;
            this.btnMining.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnMining.Click += new System.EventHandler(this.btnMining_Click);
            // 
            // btnHome
            // 
            this.btnHome.Activecolor = System.Drawing.Color.Orange;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderRadius = 0;
            this.btnHome.ButtonText = " HOME";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SidebarTransition.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.btnHome.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = global::CryptoCentral.Properties.Resources.Home_100px;
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconMarginLeft = 27;
            this.btnHome.IconMarginRight = 0;
            this.btnHome.IconRightVisible = false;
            this.btnHome.IconRightZoom = 0D;
            this.btnHome.IconVisible = true;
            this.btnHome.IconZoom = 55D;
            this.btnHome.IsTab = true;
            this.btnHome.Location = new System.Drawing.Point(0, 137);
            this.btnHome.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.Transparent;
            this.btnHome.OnHovercolor = System.Drawing.Color.Orange;
            this.btnHome.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHome.selected = false;
            this.btnHome.Size = new System.Drawing.Size(222, 36);
            this.btnHome.TabIndex = 57;
            this.btnHome.Text = " HOME";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.White;
            this.btnHome.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // FadeForm
            // 
            this.FadeForm.Delay = 1;
            // 
            // timerSummaryLoad
            // 
            this.timerSummaryLoad.Enabled = true;
            this.timerSummaryLoad.Interval = 10;
            this.timerSummaryLoad.Tick += new System.EventHandler(this.timerSummaryLoad_Tick);
            // 
            // Crypto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1940, 1071);
            this.Controls.Add(this.WorkerContainer);
            this.Controls.Add(this.OptionsContainer);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.SummaryContainer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Sidebar);
            this.Controls.Add(this.Header);
            this.SidebarTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1064, 518);
            this.Name = "Crypto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto";
            this.Load += new System.EventHandler(this.Crypto_Load);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel Header;
        public System.Windows.Forms.PictureBox btnClose;
        public System.Windows.Forms.Timer timerRefreshing;
        public System.Windows.Forms.PictureBox btnMinimize;
        public System.Windows.Forms.Timer timerSyncTimer;
        public System.Windows.Forms.Timer timerUpdating;
        public System.Windows.Forms.Panel Footer;
        public System.Windows.Forms.Label lblSyncTimer;
        public System.Windows.Forms.PictureBox gifRefreshing;
        public System.Windows.Forms.PictureBox btnRefresh;
        public System.Windows.Forms.Label lblSync;
        public System.Windows.Forms.PictureBox btnPageRight;
        public System.Windows.Forms.PictureBox btnPageLeft;
        public System.Windows.Forms.Label lblCurrentPage;
        public System.Windows.Forms.PictureBox pictureBox3;
        public Bunifu.Framework.UI.BunifuElipse RoundedCornersMain;
        private Bunifu.Framework.UI.BunifuGradientPanel Sidebar;
        public System.Windows.Forms.PictureBox Logo;
        public Bunifu.Framework.UI.BunifuFlatButton btnBack;
        public Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        public Bunifu.Framework.UI.BunifuFlatButton btnMining;
        public Bunifu.Framework.UI.BunifuFlatButton btnHome;
        public System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSeparator SidebarSeperator;
        public BunifuAnimatorNS.BunifuTransition SidebarTransition;
        public Bunifu.Framework.UI.BunifuFormFadeTransition FadeForm;
        private System.Windows.Forms.Timer timerSummaryLoad;
        public System.Windows.Forms.Panel SummaryContainer;
        public System.Windows.Forms.Panel LoadingPanel;
        public System.Windows.Forms.Panel OptionsContainer;
        public System.Windows.Forms.Panel WorkerContainer;
    }
}