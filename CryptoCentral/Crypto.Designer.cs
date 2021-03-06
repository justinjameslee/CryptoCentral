﻿namespace CryptoCentral
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
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crypto));
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            this.Header = new System.Windows.Forms.Panel();
            this.btnCompress = new System.Windows.Forms.PictureBox();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.RoundedCornersMain = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timerRefreshing = new System.Windows.Forms.Timer(this.components);
            this.timerSyncTimer = new System.Windows.Forms.Timer(this.components);
            this.timerUpdating = new System.Windows.Forms.Timer(this.components);
            this.Footer = new System.Windows.Forms.Panel();
            this.gifRefreshing = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.lblSyncTimer = new System.Windows.Forms.Label();
            this.lblSync = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.SummaryContainer = new System.Windows.Forms.Panel();
            this.SidebarTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.Background = new System.Windows.Forms.Panel();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.OptionsContainer = new System.Windows.Forms.Panel();
            this.WorkerContainer = new System.Windows.Forms.Panel();
            this.PageRight = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnPageRight = new System.Windows.Forms.PictureBox();
            this.PageLeft = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnPageLeft = new System.Windows.Forms.PictureBox();
            this.HeaderShadow = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.PageRightShadow = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.PageLeftShadow = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.Sidebar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SidebarSeperator = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnLogOut = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMining = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.PageControlTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.HeaderDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.LogoDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.UserDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.timerMinimize = new System.Windows.Forms.Timer(this.components);
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCompress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.Background.SuspendLayout();
            this.PageRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).BeginInit();
            this.PageLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).BeginInit();
            this.HeaderShadow.SuspendLayout();
            this.Sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Controls.Add(this.btnCompress);
            this.Header.Controls.Add(this.btnMaximize);
            this.Header.Controls.Add(this.Logo);
            this.Header.Controls.Add(this.btnClose);
            this.Header.Controls.Add(this.btnMinimize);
            this.Header.Controls.Add(this.lblCurrentUser);
            this.PageControlTransition.SetDecoration(this.Header, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.Header, BunifuAnimatorNS.DecorationType.None);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(5, 5);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1669, 55);
            this.Header.TabIndex = 2;
            // 
            // btnCompress
            // 
            this.btnCompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.btnCompress, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnCompress, BunifuAnimatorNS.DecorationType.None);
            this.btnCompress.Image = global::CryptoCentral.Properties.Resources.Compress_24px;
            this.btnCompress.Location = new System.Drawing.Point(1568, 15);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(24, 24);
            this.btnCompress.TabIndex = 58;
            this.btnCompress.TabStop = false;
            this.btnCompress.Click += new System.EventHandler(this.btnSizeChange_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.btnMaximize, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnMaximize, BunifuAnimatorNS.DecorationType.None);
            this.btnMaximize.Image = global::CryptoCentral.Properties.Resources.Full_Screen_24px;
            this.btnMaximize.Location = new System.Drawing.Point(1568, 15);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(24, 24);
            this.btnMaximize.TabIndex = 57;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnSizeChange_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.White;
            this.SidebarTransition.SetDecoration(this.Logo, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.Logo, BunifuAnimatorNS.DecorationType.None);
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(222, 55);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1620, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1516, 16);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 24);
            this.btnMinimize.TabIndex = 49;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.lblCurrentUser, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.lblCurrentUser, BunifuAnimatorNS.DecorationType.None);
            this.lblCurrentUser.Font = new System.Drawing.Font("Walkway Bold", 18F);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentUser.Location = new System.Drawing.Point(242, 16);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(82, 25);
            this.lblCurrentUser.TabIndex = 56;
            this.lblCurrentUser.Text = "ADMIN";
            // 
            // RoundedCornersMain
            // 
            this.RoundedCornersMain.ElipseRadius = 15;
            this.RoundedCornersMain.TargetControl = this;
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
            this.Footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Footer.Controls.Add(this.gifRefreshing);
            this.Footer.Controls.Add(this.btnRefresh);
            this.Footer.Controls.Add(this.lblSyncTimer);
            this.Footer.Controls.Add(this.lblSync);
            this.Footer.Controls.Add(this.lblCurrentPage);
            this.PageControlTransition.SetDecoration(this.Footer, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.Footer, BunifuAnimatorNS.DecorationType.None);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(227, 599);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(1447, 38);
            this.Footer.TabIndex = 6;
            // 
            // gifRefreshing
            // 
            this.gifRefreshing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.gifRefreshing, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.gifRefreshing, BunifuAnimatorNS.DecorationType.None);
            this.gifRefreshing.Image = ((System.Drawing.Image)(resources.GetObject("gifRefreshing.Image")));
            this.gifRefreshing.Location = new System.Drawing.Point(1357, 7);
            this.gifRefreshing.Name = "gifRefreshing";
            this.gifRefreshing.Size = new System.Drawing.Size(24, 24);
            this.gifRefreshing.TabIndex = 63;
            this.gifRefreshing.TabStop = false;
            this.gifRefreshing.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.btnRefresh, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnRefresh, BunifuAnimatorNS.DecorationType.None);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1356, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 62;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSyncTimer
            // 
            this.lblSyncTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSyncTimer.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.lblSyncTimer, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.lblSyncTimer, BunifuAnimatorNS.DecorationType.None);
            this.lblSyncTimer.Font = new System.Drawing.Font("Walkway Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncTimer.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSyncTimer.Location = new System.Drawing.Point(1387, 7);
            this.lblSyncTimer.Name = "lblSyncTimer";
            this.lblSyncTimer.Size = new System.Drawing.Size(49, 22);
            this.lblSyncTimer.TabIndex = 68;
            this.lblSyncTimer.Text = "(30)";
            this.lblSyncTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSync
            // 
            this.lblSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SidebarTransition.SetDecoration(this.lblSync, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.lblSync, BunifuAnimatorNS.DecorationType.None);
            this.lblSync.Font = new System.Drawing.Font("Walkway Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSync.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSync.Location = new System.Drawing.Point(1236, 9);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(112, 20);
            this.lblSync.TabIndex = 61;
            this.lblSync.Text = "SYNCED";
            this.lblSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentPage.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblCurrentPage, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.lblCurrentPage, BunifuAnimatorNS.DecorationType.None);
            this.lblCurrentPage.Font = new System.Drawing.Font("Walkway Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPage.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentPage.Location = new System.Drawing.Point(9, 9);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(73, 20);
            this.lblCurrentPage.TabIndex = 59;
            this.lblCurrentPage.Text = "PAGE 1";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerLoad
            // 
            this.timerLoad.Enabled = true;
            this.timerLoad.Interval = 10;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // SummaryContainer
            // 
            this.PageControlTransition.SetDecoration(this.SummaryContainer, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.SummaryContainer, BunifuAnimatorNS.DecorationType.None);
            this.SummaryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryContainer.Location = new System.Drawing.Point(31, 16);
            this.SummaryContainer.Name = "SummaryContainer";
            this.SummaryContainer.Size = new System.Drawing.Size(1385, 523);
            this.SummaryContainer.TabIndex = 53;
            // 
            // SidebarTransition
            // 
            this.SidebarTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.SidebarTransition.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 1F;
            this.SidebarTransition.DefaultAnimation = animation3;
            this.SidebarTransition.MaxAnimationTime = 1000;
            this.SidebarTransition.AnimationCompleted += new System.EventHandler<BunifuAnimatorNS.AnimationCompletedEventArg>(this.SidebarTransition_AnimationCompleted);
            // 
            // Background
            // 
            this.Background.AutoScroll = true;
            this.Background.Controls.Add(this.LoadingPanel);
            this.Background.Controls.Add(this.OptionsContainer);
            this.Background.Controls.Add(this.SummaryContainer);
            this.Background.Controls.Add(this.WorkerContainer);
            this.Background.Controls.Add(this.PageRight);
            this.Background.Controls.Add(this.PageLeft);
            this.Background.Controls.Add(this.HeaderShadow);
            this.PageControlTransition.SetDecoration(this.Background, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.Background, BunifuAnimatorNS.DecorationType.None);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(227, 60);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1447, 539);
            this.Background.TabIndex = 60;
            // 
            // LoadingPanel
            // 
            this.PageControlTransition.SetDecoration(this.LoadingPanel, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.LoadingPanel, BunifuAnimatorNS.DecorationType.None);
            this.LoadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingPanel.Location = new System.Drawing.Point(31, 16);
            this.LoadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(1385, 523);
            this.LoadingPanel.TabIndex = 62;
            // 
            // OptionsContainer
            // 
            this.OptionsContainer.BackColor = System.Drawing.Color.White;
            this.PageControlTransition.SetDecoration(this.OptionsContainer, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.OptionsContainer, BunifuAnimatorNS.DecorationType.None);
            this.OptionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsContainer.Location = new System.Drawing.Point(31, 16);
            this.OptionsContainer.Name = "OptionsContainer";
            this.OptionsContainer.Size = new System.Drawing.Size(1385, 523);
            this.OptionsContainer.TabIndex = 63;
            // 
            // WorkerContainer
            // 
            this.PageControlTransition.SetDecoration(this.WorkerContainer, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.WorkerContainer, BunifuAnimatorNS.DecorationType.None);
            this.WorkerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkerContainer.Location = new System.Drawing.Point(31, 16);
            this.WorkerContainer.Name = "WorkerContainer";
            this.WorkerContainer.Size = new System.Drawing.Size(1385, 523);
            this.WorkerContainer.TabIndex = 64;
            // 
            // PageRight
            // 
            this.PageRight.BackColor = System.Drawing.Color.White;
            this.PageRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PageRight.BackgroundImage")));
            this.PageRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PageRight.Controls.Add(this.btnPageRight);
            this.PageRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.PageRight, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.PageRight, BunifuAnimatorNS.DecorationType.None);
            this.PageRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PageRight.GradientBottomLeft = System.Drawing.Color.Transparent;
            this.PageRight.GradientBottomRight = System.Drawing.Color.Transparent;
            this.PageRight.GradientTopLeft = System.Drawing.Color.Transparent;
            this.PageRight.GradientTopRight = System.Drawing.Color.DarkOrange;
            this.PageRight.Location = new System.Drawing.Point(1416, 16);
            this.PageRight.Name = "PageRight";
            this.PageRight.Quality = 100;
            this.PageRight.Size = new System.Drawing.Size(31, 523);
            this.PageRight.TabIndex = 66;
            this.PageRight.Click += new System.EventHandler(this.btnPageControlClick);
            this.PageRight.MouseEnter += new System.EventHandler(this.PageRight_MouseEnter);
            this.PageRight.MouseLeave += new System.EventHandler(this.PageRight_MouseLeave);
            // 
            // btnPageRight
            // 
            this.btnPageRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPageRight.BackColor = System.Drawing.Color.Transparent;
            this.btnPageRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SidebarTransition.SetDecoration(this.btnPageRight, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnPageRight, BunifuAnimatorNS.DecorationType.None);
            this.btnPageRight.Image = global::CryptoCentral.Properties.Resources.Forward_100px;
            this.btnPageRight.Location = new System.Drawing.Point(0, 203);
            this.btnPageRight.Name = "btnPageRight";
            this.btnPageRight.Size = new System.Drawing.Size(31, 84);
            this.btnPageRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPageRight.TabIndex = 67;
            this.btnPageRight.TabStop = false;
            this.btnPageRight.Click += new System.EventHandler(this.btnPageControlClick);
            this.btnPageRight.MouseEnter += new System.EventHandler(this.PageRight_MouseEnter);
            this.btnPageRight.MouseLeave += new System.EventHandler(this.PageRight_MouseLeave);
            // 
            // PageLeft
            // 
            this.PageLeft.BackColor = System.Drawing.Color.Transparent;
            this.PageLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PageLeft.BackgroundImage")));
            this.PageLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PageLeft.Controls.Add(this.btnPageLeft);
            this.PageLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.PageLeft, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.PageLeft, BunifuAnimatorNS.DecorationType.None);
            this.PageLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PageLeft.GradientBottomLeft = System.Drawing.Color.Transparent;
            this.PageLeft.GradientBottomRight = System.Drawing.Color.Transparent;
            this.PageLeft.GradientTopLeft = System.Drawing.Color.DarkOrange;
            this.PageLeft.GradientTopRight = System.Drawing.Color.Transparent;
            this.PageLeft.Location = new System.Drawing.Point(0, 16);
            this.PageLeft.Name = "PageLeft";
            this.PageLeft.Quality = 100;
            this.PageLeft.Size = new System.Drawing.Size(31, 523);
            this.PageLeft.TabIndex = 65;
            this.PageLeft.Click += new System.EventHandler(this.btnPageControlClick);
            this.PageLeft.MouseEnter += new System.EventHandler(this.PageLeft_MouseEnter);
            this.PageLeft.MouseLeave += new System.EventHandler(this.PageLeft_MouseLeave);
            // 
            // btnPageLeft
            // 
            this.btnPageLeft.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPageLeft.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.btnPageLeft, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.btnPageLeft, BunifuAnimatorNS.DecorationType.None);
            this.btnPageLeft.Image = global::CryptoCentral.Properties.Resources.Back_100px;
            this.btnPageLeft.Location = new System.Drawing.Point(0, 203);
            this.btnPageLeft.Name = "btnPageLeft";
            this.btnPageLeft.Size = new System.Drawing.Size(31, 84);
            this.btnPageLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPageLeft.TabIndex = 1;
            this.btnPageLeft.TabStop = false;
            this.btnPageLeft.Click += new System.EventHandler(this.btnPageControlClick);
            this.btnPageLeft.MouseEnter += new System.EventHandler(this.PageLeft_MouseEnter);
            this.btnPageLeft.MouseLeave += new System.EventHandler(this.PageLeft_MouseLeave);
            // 
            // HeaderShadow
            // 
            this.HeaderShadow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HeaderShadow.BackgroundImage")));
            this.HeaderShadow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeaderShadow.Controls.Add(this.PageRightShadow);
            this.HeaderShadow.Controls.Add(this.PageLeftShadow);
            this.PageControlTransition.SetDecoration(this.HeaderShadow, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.HeaderShadow, BunifuAnimatorNS.DecorationType.None);
            this.HeaderShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderShadow.GradientBottomLeft = System.Drawing.Color.Black;
            this.HeaderShadow.GradientBottomRight = System.Drawing.Color.White;
            this.HeaderShadow.GradientTopLeft = System.Drawing.Color.White;
            this.HeaderShadow.GradientTopRight = System.Drawing.Color.White;
            this.HeaderShadow.Location = new System.Drawing.Point(0, 0);
            this.HeaderShadow.Name = "HeaderShadow";
            this.HeaderShadow.Quality = 10;
            this.HeaderShadow.Size = new System.Drawing.Size(1447, 16);
            this.HeaderShadow.TabIndex = 59;
            // 
            // PageRightShadow
            // 
            this.PageRightShadow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PageRightShadow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PageRightShadow.BackgroundImage")));
            this.PageRightShadow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PageControlTransition.SetDecoration(this.PageRightShadow, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.PageRightShadow, BunifuAnimatorNS.DecorationType.None);
            this.PageRightShadow.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.PageRightShadow.GradientBottomRight = System.Drawing.Color.White;
            this.PageRightShadow.GradientTopLeft = System.Drawing.Color.White;
            this.PageRightShadow.GradientTopRight = System.Drawing.Color.DarkOrange;
            this.PageRightShadow.Location = new System.Drawing.Point(1416, 0);
            this.PageRightShadow.Margin = new System.Windows.Forms.Padding(0);
            this.PageRightShadow.Name = "PageRightShadow";
            this.PageRightShadow.Quality = 10;
            this.PageRightShadow.Size = new System.Drawing.Size(32, 16);
            this.PageRightShadow.TabIndex = 67;
            this.PageRightShadow.Visible = false;
            // 
            // PageLeftShadow
            // 
            this.PageLeftShadow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PageLeftShadow.BackgroundImage")));
            this.PageLeftShadow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PageControlTransition.SetDecoration(this.PageLeftShadow, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.PageLeftShadow, BunifuAnimatorNS.DecorationType.None);
            this.PageLeftShadow.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.PageLeftShadow.GradientBottomRight = System.Drawing.Color.White;
            this.PageLeftShadow.GradientTopLeft = System.Drawing.Color.DarkOrange;
            this.PageLeftShadow.GradientTopRight = System.Drawing.Color.White;
            this.PageLeftShadow.Location = new System.Drawing.Point(0, 0);
            this.PageLeftShadow.Name = "PageLeftShadow";
            this.PageLeftShadow.Quality = 10;
            this.PageLeftShadow.Size = new System.Drawing.Size(31, 16);
            this.PageLeftShadow.TabIndex = 66;
            this.PageLeftShadow.Visible = false;
            // 
            // Sidebar
            // 
            this.Sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sidebar.BackgroundImage")));
            this.Sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sidebar.Controls.Add(this.pictureBox1);
            this.Sidebar.Controls.Add(this.SidebarSeperator);
            this.Sidebar.Controls.Add(this.btnLogOut);
            this.Sidebar.Controls.Add(this.btnSettings);
            this.Sidebar.Controls.Add(this.btnMining);
            this.Sidebar.Controls.Add(this.btnHome);
            this.PageControlTransition.SetDecoration(this.Sidebar, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.Sidebar, BunifuAnimatorNS.DecorationType.None);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Sidebar.Location = new System.Drawing.Point(5, 60);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Quality = 10;
            this.Sidebar.Size = new System.Drawing.Size(222, 577);
            this.Sidebar.TabIndex = 56;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Image = global::CryptoCentral.Properties.Resources.Logo_100px;
            this.pictureBox1.Location = new System.Drawing.Point(0, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // SidebarSeperator
            // 
            this.SidebarSeperator.BackColor = System.Drawing.Color.Transparent;
            this.PageControlTransition.SetDecoration(this.SidebarSeperator, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.SidebarSeperator, BunifuAnimatorNS.DecorationType.None);
            this.SidebarSeperator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.SidebarSeperator.LineThickness = 1;
            this.SidebarSeperator.Location = new System.Drawing.Point(0, 121);
            this.SidebarSeperator.Name = "SidebarSeperator";
            this.SidebarSeperator.Size = new System.Drawing.Size(222, 35);
            this.SidebarSeperator.TabIndex = 61;
            this.SidebarSeperator.Transparency = 255;
            this.SidebarSeperator.Vertical = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Activecolor = System.Drawing.Color.Orange;
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.BorderRadius = 0;
            this.btnLogOut.ButtonText = "        LOG OUT";
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.btnLogOut, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.btnLogOut, BunifuAnimatorNS.DecorationType.None);
            this.btnLogOut.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnLogOut.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogOut.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Iconimage")));
            this.btnLogOut.Iconimage_right = null;
            this.btnLogOut.Iconimage_right_Selected = null;
            this.btnLogOut.Iconimage_Selected = null;
            this.btnLogOut.IconMarginLeft = 27;
            this.btnLogOut.IconMarginRight = 0;
            this.btnLogOut.IconRightVisible = false;
            this.btnLogOut.IconRightZoom = 0D;
            this.btnLogOut.IconVisible = true;
            this.btnLogOut.IconZoom = 55D;
            this.btnLogOut.IsTab = true;
            this.btnLogOut.Location = new System.Drawing.Point(0, 539);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Normalcolor = System.Drawing.Color.Transparent;
            this.btnLogOut.OnHovercolor = System.Drawing.Color.Orange;
            this.btnLogOut.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogOut.selected = false;
            this.btnLogOut.Size = new System.Drawing.Size(222, 38);
            this.btnLogOut.TabIndex = 60;
            this.btnLogOut.Text = "        LOG OUT";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Textcolor = System.Drawing.Color.White;
            this.btnLogOut.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Activecolor = System.Drawing.Color.Orange;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.BorderRadius = 0;
            this.btnSettings.ButtonText = "        OPTIONS";
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnSettings.DisabledColor = System.Drawing.Color.Gray;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSettings.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSettings.Iconimage")));
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
            this.btnSettings.Location = new System.Drawing.Point(0, 261);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSettings.OnHovercolor = System.Drawing.Color.Orange;
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSettings.selected = false;
            this.btnSettings.Size = new System.Drawing.Size(222, 36);
            this.btnSettings.TabIndex = 59;
            this.btnSettings.Text = "        OPTIONS";
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
            this.btnMining.ButtonText = "        MINING";
            this.btnMining.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.btnMining, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.btnMining, BunifuAnimatorNS.DecorationType.None);
            this.btnMining.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnMining.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMining.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnMining.Iconimage")));
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
            this.btnMining.Location = new System.Drawing.Point(0, 213);
            this.btnMining.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMining.Name = "btnMining";
            this.btnMining.Normalcolor = System.Drawing.Color.Transparent;
            this.btnMining.OnHovercolor = System.Drawing.Color.Orange;
            this.btnMining.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMining.selected = false;
            this.btnMining.Size = new System.Drawing.Size(222, 36);
            this.btnMining.TabIndex = 58;
            this.btnMining.Text = "        MINING";
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
            this.btnHome.ButtonText = "        HOME";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PageControlTransition.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.SidebarTransition.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.btnHome.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHome.Iconimage")));
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
            this.btnHome.Location = new System.Drawing.Point(0, 165);
            this.btnHome.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.Transparent;
            this.btnHome.OnHovercolor = System.Drawing.Color.Orange;
            this.btnHome.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHome.selected = false;
            this.btnHome.Size = new System.Drawing.Size(222, 36);
            this.btnHome.TabIndex = 57;
            this.btnHome.Text = "        HOME";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.White;
            this.btnHome.TextFont = new System.Drawing.Font("Walkway Bold", 14F);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // PageControlTransition
            // 
            this.PageControlTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.PageControlTransition.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 1F;
            this.PageControlTransition.DefaultAnimation = animation4;
            this.PageControlTransition.MaxAnimationTime = 250;
            this.PageControlTransition.TimeStep = 0.12F;
            // 
            // HeaderDrag
            // 
            this.HeaderDrag.Fixed = true;
            this.HeaderDrag.Horizontal = true;
            this.HeaderDrag.TargetControl = this.Header;
            this.HeaderDrag.Vertical = true;
            // 
            // LogoDrag
            // 
            this.LogoDrag.Fixed = true;
            this.LogoDrag.Horizontal = true;
            this.LogoDrag.TargetControl = this.Logo;
            this.LogoDrag.Vertical = true;
            // 
            // UserDrag
            // 
            this.UserDrag.Fixed = true;
            this.UserDrag.Horizontal = true;
            this.UserDrag.TargetControl = this.lblCurrentUser;
            this.UserDrag.Vertical = true;
            // 
            // timerMinimize
            // 
            this.timerMinimize.Tick += new System.EventHandler(this.timerMinimize_Tick);
            // 
            // Crypto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1679, 642);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Sidebar);
            this.Controls.Add(this.Header);
            this.SidebarTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.PageControlTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1135, 642);
            this.Name = "Crypto";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto";
            this.Load += new System.EventHandler(this.Crypto_Load);
            this.Resize += new System.EventHandler(this.Crypto_Resize);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCompress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.Background.ResumeLayout(false);
            this.PageRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).EndInit();
            this.PageLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).EndInit();
            this.HeaderShadow.ResumeLayout(false);
            this.Sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Header;
        public System.Windows.Forms.PictureBox btnCompress;
        public BunifuAnimatorNS.BunifuTransition SidebarTransition;
        public System.Windows.Forms.PictureBox btnMaximize;
        public System.Windows.Forms.PictureBox Logo;
        public System.Windows.Forms.PictureBox btnClose;
        public System.Windows.Forms.PictureBox btnMinimize;
        public System.Windows.Forms.Label lblCurrentUser;
        public Bunifu.Framework.UI.BunifuElipse RoundedCornersMain;
        public System.Windows.Forms.Panel SummaryContainer;
        public System.Windows.Forms.Panel Footer;
        public System.Windows.Forms.PictureBox gifRefreshing;
        public System.Windows.Forms.PictureBox btnRefresh;
        public System.Windows.Forms.Label lblSyncTimer;
        public System.Windows.Forms.Label lblSync;
        public System.Windows.Forms.Label lblCurrentPage;
        private Bunifu.Framework.UI.BunifuGradientPanel Sidebar;
        private Bunifu.Framework.UI.BunifuSeparator SidebarSeperator;
        public Bunifu.Framework.UI.BunifuFlatButton btnLogOut;
        public Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        public Bunifu.Framework.UI.BunifuFlatButton btnMining;
        public Bunifu.Framework.UI.BunifuFlatButton btnHome;
        public System.Windows.Forms.Timer timerRefreshing;
        public System.Windows.Forms.Timer timerSyncTimer;
        public System.Windows.Forms.Timer timerUpdating;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Panel Background;
        private Bunifu.Framework.UI.BunifuGradientPanel HeaderShadow;
        public System.Windows.Forms.Panel LoadingPanel;
        public System.Windows.Forms.Panel OptionsContainer;
        public System.Windows.Forms.Panel WorkerContainer;
        public Bunifu.Framework.UI.BunifuGradientPanel PageLeft;
        private Bunifu.Framework.UI.BunifuGradientPanel PageLeftShadow;
        public Bunifu.Framework.UI.BunifuGradientPanel PageRight;
        private Bunifu.Framework.UI.BunifuGradientPanel PageRightShadow;
        private System.Windows.Forms.PictureBox btnPageLeft;
        private BunifuAnimatorNS.BunifuTransition PageControlTransition;
        private System.Windows.Forms.PictureBox btnPageRight;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDrag;
        private Bunifu.Framework.UI.BunifuDragControl LogoDrag;
        private Bunifu.Framework.UI.BunifuDragControl UserDrag;
        private System.Windows.Forms.Timer timerMinimize;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}