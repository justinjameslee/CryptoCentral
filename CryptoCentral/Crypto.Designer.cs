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
            this.Mining01 = new System.Windows.Forms.Panel();
            this.groupMiningWorker = new System.Windows.Forms.GroupBox();
            this.MiningZPOOL = new System.Windows.Forms.Label();
            this.MiningNH = new System.Windows.Forms.PictureBox();
            this.groupWorkerAddress = new System.Windows.Forms.GroupBox();
            this.lblWorkerAddress = new System.Windows.Forms.Label();
            this.groupWorkerDetails = new System.Windows.Forms.GroupBox();
            this.lblMiningWorkerSeperator = new System.Windows.Forms.Label();
            this.lblWorkerRejectv = new System.Windows.Forms.Label();
            this.lblWorkerEfficiencyv = new System.Windows.Forms.Label();
            this.lblWorkerHashv = new System.Windows.Forms.Label();
            this.lblWorkerHash = new System.Windows.Forms.Label();
            this.lblWorkerVerifiedv = new System.Windows.Forms.Label();
            this.lblWorkerEfficiency = new System.Windows.Forms.Label();
            this.lblWorkerReject = new System.Windows.Forms.Label();
            this.lblWorkerVerified = new System.Windows.Forms.Label();
            this.lblWorkerDifficultyv = new System.Windows.Forms.Label();
            this.lblWorkerDifficulty = new System.Windows.Forms.Label();
            this.lblWorkerUpTimev = new System.Windows.Forms.Label();
            this.lblWorkerUpTime = new System.Windows.Forms.Label();
            this.lblWorkerAlgov = new System.Windows.Forms.Label();
            this.lblWorkerAlgo = new System.Windows.Forms.Label();
            this.lblWorkerIDv = new System.Windows.Forms.Label();
            this.lblWorkerID = new System.Windows.Forms.Label();
            this.groupWorkerProfitability = new System.Windows.Forms.GroupBox();
            this.lblProfitY = new System.Windows.Forms.Label();
            this.lblProfitM = new System.Windows.Forms.Label();
            this.lblProfitYv = new System.Windows.Forms.Label();
            this.lblProfitMv = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitv = new System.Windows.Forms.Label();
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.RoundedCornersMain = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SidebarTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.MainContainer = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMining = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.FadeForm = new Bunifu.Framework.UI.BunifuFormFadeTransition(this.components);
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.Mining01.SuspendLayout();
            this.groupMiningWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiningNH)).BeginInit();
            this.groupWorkerAddress.SuspendLayout();
            this.groupWorkerDetails.SuspendLayout();
            this.groupWorkerProfitability.SuspendLayout();
            this.Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.MainContainer.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(803, 16);
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
            this.btnMinimize.Location = new System.Drawing.Point(751, 16);
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
            // Mining01
            // 
            this.Mining01.BackColor = System.Drawing.Color.White;
            this.Mining01.Controls.Add(this.groupMiningWorker);
            this.SidebarTransition.SetDecoration(this.Mining01, BunifuAnimatorNS.DecorationType.None);
            this.Mining01.Location = new System.Drawing.Point(228, 545);
            this.Mining01.Name = "Mining01";
            this.Mining01.Size = new System.Drawing.Size(842, 468);
            this.Mining01.TabIndex = 5;
            // 
            // groupMiningWorker
            // 
            this.groupMiningWorker.Controls.Add(this.MiningZPOOL);
            this.groupMiningWorker.Controls.Add(this.MiningNH);
            this.groupMiningWorker.Controls.Add(this.groupWorkerAddress);
            this.groupMiningWorker.Controls.Add(this.groupWorkerDetails);
            this.groupMiningWorker.Controls.Add(this.groupWorkerProfitability);
            this.SidebarTransition.SetDecoration(this.groupMiningWorker, BunifuAnimatorNS.DecorationType.None);
            this.groupMiningWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.groupMiningWorker.ForeColor = System.Drawing.Color.Black;
            this.groupMiningWorker.Location = new System.Drawing.Point(5, 6);
            this.groupMiningWorker.Name = "groupMiningWorker";
            this.groupMiningWorker.Size = new System.Drawing.Size(828, 455);
            this.groupMiningWorker.TabIndex = 50;
            this.groupMiningWorker.TabStop = false;
            this.groupMiningWorker.Text = "WORKER";
            // 
            // MiningZPOOL
            // 
            this.MiningZPOOL.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.MiningZPOOL, BunifuAnimatorNS.DecorationType.None);
            this.MiningZPOOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F);
            this.MiningZPOOL.Location = new System.Drawing.Point(26, 30);
            this.MiningZPOOL.Name = "MiningZPOOL";
            this.MiningZPOOL.Size = new System.Drawing.Size(218, 64);
            this.MiningZPOOL.TabIndex = 50;
            this.MiningZPOOL.Text = "ZPOOL";
            // 
            // MiningNH
            // 
            this.SidebarTransition.SetDecoration(this.MiningNH, BunifuAnimatorNS.DecorationType.None);
            this.MiningNH.Image = ((System.Drawing.Image)(resources.GetObject("MiningNH.Image")));
            this.MiningNH.Location = new System.Drawing.Point(596, 65);
            this.MiningNH.Name = "MiningNH";
            this.MiningNH.Size = new System.Drawing.Size(220, 58);
            this.MiningNH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MiningNH.TabIndex = 49;
            this.MiningNH.TabStop = false;
            this.MiningNH.Click += new System.EventHandler(this.MiningNH_Click);
            // 
            // groupWorkerAddress
            // 
            this.groupWorkerAddress.Controls.Add(this.lblWorkerAddress);
            this.SidebarTransition.SetDecoration(this.groupWorkerAddress, BunifuAnimatorNS.DecorationType.None);
            this.groupWorkerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.groupWorkerAddress.ForeColor = System.Drawing.Color.Black;
            this.groupWorkerAddress.Location = new System.Drawing.Point(277, 38);
            this.groupWorkerAddress.Name = "groupWorkerAddress";
            this.groupWorkerAddress.Size = new System.Drawing.Size(541, 52);
            this.groupWorkerAddress.TabIndex = 48;
            this.groupWorkerAddress.TabStop = false;
            this.groupWorkerAddress.Text = "ADDRESS";
            // 
            // lblWorkerAddress
            // 
            this.lblWorkerAddress.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblWorkerAddress, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWorkerAddress.Location = new System.Drawing.Point(6, 27);
            this.lblWorkerAddress.Name = "lblWorkerAddress";
            this.lblWorkerAddress.Size = new System.Drawing.Size(68, 20);
            this.lblWorkerAddress.TabIndex = 23;
            this.lblWorkerAddress.Text = "No Data";
            this.lblWorkerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupWorkerDetails
            // 
            this.groupWorkerDetails.Controls.Add(this.lblMiningWorkerSeperator);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerRejectv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerEfficiencyv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerHashv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerHash);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerVerifiedv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerEfficiency);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerReject);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerVerified);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerDifficultyv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerDifficulty);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerUpTimev);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerUpTime);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerAlgov);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerAlgo);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerIDv);
            this.groupWorkerDetails.Controls.Add(this.lblWorkerID);
            this.SidebarTransition.SetDecoration(this.groupWorkerDetails, BunifuAnimatorNS.DecorationType.None);
            this.groupWorkerDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupWorkerDetails.ForeColor = System.Drawing.Color.Black;
            this.groupWorkerDetails.Location = new System.Drawing.Point(14, 231);
            this.groupWorkerDetails.Name = "groupWorkerDetails";
            this.groupWorkerDetails.Size = new System.Drawing.Size(804, 213);
            this.groupWorkerDetails.TabIndex = 47;
            this.groupWorkerDetails.TabStop = false;
            this.groupWorkerDetails.Text = "WORKER DETAILS";
            // 
            // lblMiningWorkerSeperator
            // 
            this.lblMiningWorkerSeperator.BackColor = System.Drawing.Color.Black;
            this.SidebarTransition.SetDecoration(this.lblMiningWorkerSeperator, BunifuAnimatorNS.DecorationType.None);
            this.lblMiningWorkerSeperator.Location = new System.Drawing.Point(442, 46);
            this.lblMiningWorkerSeperator.Name = "lblMiningWorkerSeperator";
            this.lblMiningWorkerSeperator.Size = new System.Drawing.Size(2, 152);
            this.lblMiningWorkerSeperator.TabIndex = 43;
            this.lblMiningWorkerSeperator.Text = "label4";
            // 
            // lblWorkerRejectv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerRejectv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerRejectv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerRejectv.ForeColor = System.Drawing.Color.Black;
            this.lblWorkerRejectv.Location = new System.Drawing.Point(609, 163);
            this.lblWorkerRejectv.Name = "lblWorkerRejectv";
            this.lblWorkerRejectv.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerRejectv.TabIndex = 42;
            this.lblWorkerRejectv.Text = "No Data";
            this.lblWorkerRejectv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerEfficiencyv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerEfficiencyv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerEfficiencyv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerEfficiencyv.ForeColor = System.Drawing.Color.Black;
            this.lblWorkerEfficiencyv.Location = new System.Drawing.Point(609, 87);
            this.lblWorkerEfficiencyv.Name = "lblWorkerEfficiencyv";
            this.lblWorkerEfficiencyv.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerEfficiencyv.TabIndex = 41;
            this.lblWorkerEfficiencyv.Text = "No Data";
            this.lblWorkerEfficiencyv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerHashv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerHashv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerHashv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerHashv.ForeColor = System.Drawing.Color.Black;
            this.lblWorkerHashv.Location = new System.Drawing.Point(443, 163);
            this.lblWorkerHashv.Name = "lblWorkerHashv";
            this.lblWorkerHashv.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerHashv.TabIndex = 40;
            this.lblWorkerHashv.Text = "No Data";
            this.lblWorkerHashv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerHash
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerHash, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerHash.Location = new System.Drawing.Point(443, 125);
            this.lblWorkerHash.Name = "lblWorkerHash";
            this.lblWorkerHash.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerHash.TabIndex = 39;
            this.lblWorkerHash.Text = "HASH RATE";
            this.lblWorkerHash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerVerifiedv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerVerifiedv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerVerifiedv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerVerifiedv.ForeColor = System.Drawing.Color.Black;
            this.lblWorkerVerifiedv.Location = new System.Drawing.Point(443, 87);
            this.lblWorkerVerifiedv.Name = "lblWorkerVerifiedv";
            this.lblWorkerVerifiedv.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerVerifiedv.TabIndex = 38;
            this.lblWorkerVerifiedv.Text = "No Data";
            this.lblWorkerVerifiedv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerEfficiency
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerEfficiency, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerEfficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerEfficiency.Location = new System.Drawing.Point(609, 49);
            this.lblWorkerEfficiency.Name = "lblWorkerEfficiency";
            this.lblWorkerEfficiency.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerEfficiency.TabIndex = 37;
            this.lblWorkerEfficiency.Text = "EFFICIENCY";
            this.lblWorkerEfficiency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerReject
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerReject, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerReject.Location = new System.Drawing.Point(609, 125);
            this.lblWorkerReject.Name = "lblWorkerReject";
            this.lblWorkerReject.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerReject.TabIndex = 35;
            this.lblWorkerReject.Text = "REJECTED";
            this.lblWorkerReject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerVerified
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerVerified, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerVerified.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerVerified.Location = new System.Drawing.Point(443, 49);
            this.lblWorkerVerified.Name = "lblWorkerVerified";
            this.lblWorkerVerified.Size = new System.Drawing.Size(168, 29);
            this.lblWorkerVerified.TabIndex = 34;
            this.lblWorkerVerified.Text = "VERIFIED";
            this.lblWorkerVerified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkerDifficultyv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerDifficultyv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerDifficultyv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerDifficultyv.Location = new System.Drawing.Point(174, 125);
            this.lblWorkerDifficultyv.Name = "lblWorkerDifficultyv";
            this.lblWorkerDifficultyv.Size = new System.Drawing.Size(258, 29);
            this.lblWorkerDifficultyv.TabIndex = 33;
            this.lblWorkerDifficultyv.Text = "No Data";
            this.lblWorkerDifficultyv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkerDifficulty
            // 
            this.lblWorkerDifficulty.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblWorkerDifficulty, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerDifficulty.Location = new System.Drawing.Point(7, 125);
            this.lblWorkerDifficulty.Name = "lblWorkerDifficulty";
            this.lblWorkerDifficulty.Size = new System.Drawing.Size(151, 29);
            this.lblWorkerDifficulty.TabIndex = 32;
            this.lblWorkerDifficulty.Text = "DIFFICULTY";
            this.lblWorkerDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkerUpTimev
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerUpTimev, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerUpTimev.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerUpTimev.Location = new System.Drawing.Point(174, 163);
            this.lblWorkerUpTimev.Name = "lblWorkerUpTimev";
            this.lblWorkerUpTimev.Size = new System.Drawing.Size(258, 29);
            this.lblWorkerUpTimev.TabIndex = 31;
            this.lblWorkerUpTimev.Text = "No Data";
            this.lblWorkerUpTimev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkerUpTime
            // 
            this.lblWorkerUpTime.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblWorkerUpTime, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerUpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerUpTime.Location = new System.Drawing.Point(7, 163);
            this.lblWorkerUpTime.Name = "lblWorkerUpTime";
            this.lblWorkerUpTime.Size = new System.Drawing.Size(110, 29);
            this.lblWorkerUpTime.TabIndex = 30;
            this.lblWorkerUpTime.Text = "UP TIME";
            this.lblWorkerUpTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkerAlgov
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerAlgov, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerAlgov.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerAlgov.Location = new System.Drawing.Point(174, 87);
            this.lblWorkerAlgov.Name = "lblWorkerAlgov";
            this.lblWorkerAlgov.Size = new System.Drawing.Size(258, 29);
            this.lblWorkerAlgov.TabIndex = 29;
            this.lblWorkerAlgov.Text = "No Data";
            this.lblWorkerAlgov.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkerAlgo
            // 
            this.lblWorkerAlgo.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblWorkerAlgo, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerAlgo.Location = new System.Drawing.Point(7, 87);
            this.lblWorkerAlgo.Name = "lblWorkerAlgo";
            this.lblWorkerAlgo.Size = new System.Drawing.Size(154, 29);
            this.lblWorkerAlgo.TabIndex = 28;
            this.lblWorkerAlgo.Text = "ALGORITHM";
            this.lblWorkerAlgo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkerIDv
            // 
            this.SidebarTransition.SetDecoration(this.lblWorkerIDv, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerIDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerIDv.Location = new System.Drawing.Point(174, 49);
            this.lblWorkerIDv.Name = "lblWorkerIDv";
            this.lblWorkerIDv.Size = new System.Drawing.Size(258, 29);
            this.lblWorkerIDv.TabIndex = 27;
            this.lblWorkerIDv.Text = "No Data";
            this.lblWorkerIDv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkerID
            // 
            this.lblWorkerID.AutoSize = true;
            this.SidebarTransition.SetDecoration(this.lblWorkerID, BunifuAnimatorNS.DecorationType.None);
            this.lblWorkerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblWorkerID.Location = new System.Drawing.Point(7, 49);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.Size = new System.Drawing.Size(149, 29);
            this.lblWorkerID.TabIndex = 26;
            this.lblWorkerID.Text = "WORKER ID";
            this.lblWorkerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupWorkerProfitability
            // 
            this.groupWorkerProfitability.BackColor = System.Drawing.Color.White;
            this.groupWorkerProfitability.Controls.Add(this.lblProfitY);
            this.groupWorkerProfitability.Controls.Add(this.lblProfitM);
            this.groupWorkerProfitability.Controls.Add(this.lblProfitYv);
            this.groupWorkerProfitability.Controls.Add(this.lblProfitMv);
            this.groupWorkerProfitability.Controls.Add(this.lblProfit);
            this.groupWorkerProfitability.Controls.Add(this.lblProfitv);
            this.SidebarTransition.SetDecoration(this.groupWorkerProfitability, BunifuAnimatorNS.DecorationType.None);
            this.groupWorkerProfitability.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupWorkerProfitability.ForeColor = System.Drawing.Color.Black;
            this.groupWorkerProfitability.Location = new System.Drawing.Point(14, 107);
            this.groupWorkerProfitability.Name = "groupWorkerProfitability";
            this.groupWorkerProfitability.Size = new System.Drawing.Size(804, 118);
            this.groupWorkerProfitability.TabIndex = 46;
            this.groupWorkerProfitability.TabStop = false;
            this.groupWorkerProfitability.Text = "PROFITABILITY";
            // 
            // lblProfitY
            // 
            this.SidebarTransition.SetDecoration(this.lblProfitY, BunifuAnimatorNS.DecorationType.None);
            this.lblProfitY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProfitY.ForeColor = System.Drawing.Color.Black;
            this.lblProfitY.Location = new System.Drawing.Point(535, 75);
            this.lblProfitY.Name = "lblProfitY";
            this.lblProfitY.Size = new System.Drawing.Size(267, 29);
            this.lblProfitY.TabIndex = 34;
            this.lblProfitY.Text = "BTC/YEAR";
            this.lblProfitY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfitM
            // 
            this.SidebarTransition.SetDecoration(this.lblProfitM, BunifuAnimatorNS.DecorationType.None);
            this.lblProfitM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProfitM.ForeColor = System.Drawing.Color.Black;
            this.lblProfitM.Location = new System.Drawing.Point(268, 78);
            this.lblProfitM.Name = "lblProfitM";
            this.lblProfitM.Size = new System.Drawing.Size(267, 29);
            this.lblProfitM.TabIndex = 33;
            this.lblProfitM.Text = "BTC/MONTH";
            this.lblProfitM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfitYv
            // 
            this.SidebarTransition.SetDecoration(this.lblProfitYv, BunifuAnimatorNS.DecorationType.None);
            this.lblProfitYv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblProfitYv.ForeColor = System.Drawing.Color.Black;
            this.lblProfitYv.Location = new System.Drawing.Point(535, 43);
            this.lblProfitYv.Name = "lblProfitYv";
            this.lblProfitYv.Size = new System.Drawing.Size(267, 29);
            this.lblProfitYv.TabIndex = 31;
            this.lblProfitYv.Text = "No Data";
            this.lblProfitYv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfitMv
            // 
            this.SidebarTransition.SetDecoration(this.lblProfitMv, BunifuAnimatorNS.DecorationType.None);
            this.lblProfitMv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblProfitMv.ForeColor = System.Drawing.Color.Black;
            this.lblProfitMv.Location = new System.Drawing.Point(268, 43);
            this.lblProfitMv.Name = "lblProfitMv";
            this.lblProfitMv.Size = new System.Drawing.Size(267, 29);
            this.lblProfitMv.TabIndex = 29;
            this.lblProfitMv.Text = "No Data";
            this.lblProfitMv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfit
            // 
            this.SidebarTransition.SetDecoration(this.lblProfit, BunifuAnimatorNS.DecorationType.None);
            this.lblProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProfit.ForeColor = System.Drawing.Color.Black;
            this.lblProfit.Location = new System.Drawing.Point(1, 78);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(267, 29);
            this.lblProfit.TabIndex = 28;
            this.lblProfit.Text = "BTC/DAY";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfitv
            // 
            this.SidebarTransition.SetDecoration(this.lblProfitv, BunifuAnimatorNS.DecorationType.None);
            this.lblProfitv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblProfitv.ForeColor = System.Drawing.Color.Black;
            this.lblProfitv.Location = new System.Drawing.Point(1, 43);
            this.lblProfitv.Name = "lblProfitv";
            this.lblProfitv.Size = new System.Drawing.Size(267, 29);
            this.lblProfitv.TabIndex = 24;
            this.lblProfitv.Text = "No Data";
            this.lblProfitv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.LoadingPanel);
            this.SidebarTransition.SetDecoration(this.MainContainer, BunifuAnimatorNS.DecorationType.None);
            this.MainContainer.Location = new System.Drawing.Point(222, 71);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(843, 468);
            this.MainContainer.TabIndex = 53;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuSeparator1);
            this.bunifuGradientPanel1.Controls.Add(this.btnBack);
            this.bunifuGradientPanel1.Controls.Add(this.btnSettings);
            this.bunifuGradientPanel1.Controls.Add(this.btnMining);
            this.bunifuGradientPanel1.Controls.Add(this.btnHome);
            this.SidebarTransition.SetDecoration(this.bunifuGradientPanel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 55);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(222, 1016);
            this.bunifuGradientPanel1.TabIndex = 56;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.SidebarTransition.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 93);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(222, 35);
            this.bunifuSeparator1.TabIndex = 61;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
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
            this.btnBack.IconRightVisible = true;
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
            this.btnSettings.IconRightVisible = true;
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
            this.btnMining.DisabledColor = System.Drawing.Color.Gray;
            this.btnMining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnMining.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMining.Iconimage = global::CryptoCentral.Properties.Resources.Golden_Fever_100px;
            this.btnMining.Iconimage_right = null;
            this.btnMining.Iconimage_right_Selected = null;
            this.btnMining.Iconimage_Selected = null;
            this.btnMining.IconMarginLeft = 27;
            this.btnMining.IconMarginRight = 0;
            this.btnMining.IconRightVisible = true;
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
            this.btnHome.DisabledColor = System.Drawing.Color.Gray;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = global::CryptoCentral.Properties.Resources.Home_100px;
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconMarginLeft = 27;
            this.btnHome.IconMarginRight = 0;
            this.btnHome.IconRightVisible = true;
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
            // LoadingPanel
            // 
            this.SidebarTransition.SetDecoration(this.LoadingPanel, BunifuAnimatorNS.DecorationType.None);
            this.LoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(843, 468);
            this.LoadingPanel.TabIndex = 54;
            // 
            // Crypto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1940, 1071);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Mining01);
            this.Controls.Add(this.bunifuGradientPanel1);
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
            this.Mining01.ResumeLayout(false);
            this.groupMiningWorker.ResumeLayout(false);
            this.groupMiningWorker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiningNH)).EndInit();
            this.groupWorkerAddress.ResumeLayout(false);
            this.groupWorkerAddress.PerformLayout();
            this.groupWorkerDetails.ResumeLayout(false);
            this.groupWorkerDetails.PerformLayout();
            this.groupWorkerProfitability.ResumeLayout(false);
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifRefreshing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel Header;
        public System.Windows.Forms.PictureBox btnClose;
        public System.Windows.Forms.Panel Mining01;
        public System.Windows.Forms.Timer timerRefreshing;
        public System.Windows.Forms.PictureBox btnMinimize;
        public System.Windows.Forms.GroupBox groupMiningWorker;
        public System.Windows.Forms.GroupBox groupWorkerAddress;
        public System.Windows.Forms.Label lblWorkerAddress;
        public System.Windows.Forms.GroupBox groupWorkerDetails;
        public System.Windows.Forms.GroupBox groupWorkerProfitability;
        public System.Windows.Forms.Label lblProfitv;
        public System.Windows.Forms.Label lblWorkerAlgov;
        public System.Windows.Forms.Label lblWorkerAlgo;
        public System.Windows.Forms.Label lblWorkerIDv;
        public System.Windows.Forms.Label lblWorkerID;
        public System.Windows.Forms.Label lblWorkerDifficultyv;
        public System.Windows.Forms.Label lblWorkerDifficulty;
        public System.Windows.Forms.Label lblWorkerUpTimev;
        public System.Windows.Forms.Label lblWorkerUpTime;
        public System.Windows.Forms.Label lblWorkerVerified;
        public System.Windows.Forms.Label lblWorkerEfficiency;
        public System.Windows.Forms.Label lblWorkerReject;
        public System.Windows.Forms.Label lblProfit;
        public System.Windows.Forms.Label lblWorkerVerifiedv;
        public System.Windows.Forms.Label lblWorkerHash;
        public System.Windows.Forms.Label lblWorkerHashv;
        public System.Windows.Forms.Label lblWorkerEfficiencyv;
        public System.Windows.Forms.Label lblWorkerRejectv;
        public System.Windows.Forms.Timer timerSyncTimer;
        public System.Windows.Forms.Timer timerUpdating;
        public System.Windows.Forms.Label lblProfitYv;
        public System.Windows.Forms.Label lblProfitMv;
        public System.Windows.Forms.Label lblProfitY;
        public System.Windows.Forms.Label lblProfitM;
        public System.Windows.Forms.Panel Footer;
        public System.Windows.Forms.Label lblSyncTimer;
        public System.Windows.Forms.PictureBox gifRefreshing;
        public System.Windows.Forms.PictureBox btnRefresh;
        public System.Windows.Forms.Label lblSync;
        public System.Windows.Forms.PictureBox btnPageRight;
        public System.Windows.Forms.PictureBox btnPageLeft;
        public System.Windows.Forms.Label lblCurrentPage;
        public System.Windows.Forms.PictureBox MiningNH;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label lblMiningWorkerSeperator;
        public System.Windows.Forms.Label MiningZPOOL;
        public Bunifu.Framework.UI.BunifuElipse RoundedCornersMain;
        private System.Windows.Forms.Panel MainContainer;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        public System.Windows.Forms.PictureBox Logo;
        public Bunifu.Framework.UI.BunifuFlatButton btnBack;
        public Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        public Bunifu.Framework.UI.BunifuFlatButton btnMining;
        public Bunifu.Framework.UI.BunifuFlatButton btnHome;
        public System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public BunifuAnimatorNS.BunifuTransition SidebarTransition;
        public Bunifu.Framework.UI.BunifuFormFadeTransition FadeForm;
        private System.Windows.Forms.Panel LoadingPanel;
    }
}